using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace SeuProjeto.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Alterado para método assíncrono
        public async Task EnviarEmailAsync(string destinatario, string assunto, string corpo)
        {
            // Recuperando as configurações do arquivo appsettings.json
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            var smtpUser = _configuration["EmailSettings:SmtpUser"];
            var smtpPass = _configuration["EmailSettings:SmtpPass"];

            var mensagem = new MailMessage
            {
                From = new MailAddress(smtpUser),
                Subject = assunto,
                Body = corpo,
                IsBodyHtml = true
            };

            mensagem.To.Add(destinatario);

            // Utilizando o cliente SMTP com a configuração de envio assíncrono
            using (var cliente = new SmtpClient(smtpServer, smtpPort))
            {
                cliente.Credentials = new NetworkCredential(smtpUser, smtpPass);
                cliente.EnableSsl = true;

                // Envio assíncrono do e-mail
                await cliente.SendMailAsync(mensagem);
            }
        }
    }
}
