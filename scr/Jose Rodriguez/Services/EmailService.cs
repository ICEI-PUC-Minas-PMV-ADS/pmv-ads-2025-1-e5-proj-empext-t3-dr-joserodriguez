using MailKit.Net.Smtp;
using MimeKit;

public class EmailService
{
    public void EnviarResetSenha(string destinatario, string token)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Seu App", "consultoriojose@dominio.com"));
        message.To.Add(new MailboxAddress("", destinatario));
        message.Subject = "Redefinição de Senha";

        message.Body = new TextPart("plain")
        {
            Text = $"Clique no link para redefinir sua senha: https://seusite.com/ResetPassword/Confirm?token={token}"
        };

        using var client = new SmtpClient();
        client.Connect("smtp.seuprovedor.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        client.Authenticate("seu-email@dominio.com", "sua-senha");
        client.Send(message);
        client.Disconnect(true);
    }
}