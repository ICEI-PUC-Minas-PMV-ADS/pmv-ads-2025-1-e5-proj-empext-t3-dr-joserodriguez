using Microsoft.AspNetCore.Mvc;
using SeuProjeto.Models;
using SeuProjeto.Services;

namespace SeuProjeto.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly EmailService _emailService;

        // Injeção de dependência do serviço de e-mail
        public AgendamentosController(EmailService emailService)
        {
            _emailService = emailService;
        }

        // Ação GET para exibir o formulário de agendamento
        public IActionResult Index()
        {
            return View(new AgendamentoViewModel());
        }

        // Ação POST para enviar o agendamento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Enviar(AgendamentoViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model); // Retorna o formulário com erros de validação

            // Preparando o assunto do e-mail
            string assunto = "Novo Agendamento de Consulta";

            // Criando o corpo do e-mail com as informações do modelo
            string corpo = $@"
                <h3>Detalhes do Agendamento</h3>
                <p><strong>Nome:</strong> {model.Nome}</p>
                <p><strong>Email:</strong> {model.Email}</p>
                <p><strong>Telefone:</strong> {model.Telefone}</p>
                <p><strong>Data:</strong> {model.DataConsulta:dd/MM/yyyy}</p>
                <p><strong>Horário:</strong> {model.AppointmentTime}</p>
                <p><strong>Especialidade:</strong> {model.Especialidade}</p>";

            // Adiciona a mensagem se existir
            if (!string.IsNullOrEmpty(model.Mensagem))
            {
                corpo += $@"<p><strong>Mensagem:</strong> {model.Mensagem}</p>";
            }

            // Enviar o e-mail usando o serviço
            _emailService.EnviarEmailAsync("consultoriodontovip@gmail.com", assunto, corpo);

            // Exibe uma mensagem de sucesso e redireciona de volta para a página de agendamento
            TempData["SuccessMessage"] = "Agendamento enviado com sucesso!";
            return RedirectToAction("Index");
        }
    }
}