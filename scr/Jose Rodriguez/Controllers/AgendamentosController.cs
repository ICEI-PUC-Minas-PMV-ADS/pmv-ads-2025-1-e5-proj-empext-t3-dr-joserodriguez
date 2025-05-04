using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginCadastroMVC.Models;
using SeuProjeto.Services;
using SeuProjeto.Models;

namespace LoginCadastroMVC.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly EmailService _emailService;

        public AgendamentosController(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            var model = new AgendamentoViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enviar(AgendamentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var emailBody = GetEmailBody(model);
                    var subject = $"Novo Agendamento - {model.Nome}";

                    // Usa o EmailService para enviar
                    await _emailService.EnviarEmailAsync(
                        "consultoriodontovip2025@gmail.com", // destinatário
                        subject,
                        emailBody
                    );

                    TempData["SuccessMessage"] = "Agendamento realizado com sucesso! Em breve entraremos em contato.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Erro ao enviar o agendamento: {ex.Message}");
                }
            }

            return View("Index", model);
        }

        private string GetEmailBody(AgendamentoViewModel model)
        {
            return $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 20px; }}
                        .container {{ max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 8px; box-shadow: 0 2px 4px rgba(0,0,0,0.1); }}
                        .header {{ background-color: #C6A16F; color: white; padding: 20px; border-radius: 8px 8px 0 0; text-align: center; }}
                        .content {{ padding: 30px; }}
                        .field {{ margin-bottom: 20px; }}
                        .label {{ font-weight: bold; color: #333; margin-bottom: 5px; display: block; }}
                        .value {{ color: #555; padding: 10px; background-color: #f8f9fa; border-radius: 4px; }}
                        .footer {{ background-color: #f8f9fa; padding: 15px; text-align: center; border-radius: 0 0 8px 8px; font-size: 12px; color: #666; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h2>Novo Agendamento Odontológico</h2>
                        </div>
                        <div class='content'>
                            <div class='field'>
                                <div class='label'>Nome do Paciente:</div>
                                <div class='value'>{model.Nome}</div>
                            </div>
                            <div class='field'>
                                <div class='label'>Email:</div>
                                <div class='value'>{model.Email}</div>
                            </div>
                            <div class='field'>
                                <div class='label'>Telefone:</div>
                                <div class='value'>{model.Telefone}</div>
                            </div>
                            <div class='field'>
                                <div class='label'>Especialidade:</div>
                                <div class='value'>{model.Especialidade}</div>
                            </div>
                            <div class='field'>
                                <div class='label'>Data e Hora:</div>
                                <div class='value'>{model.DataHora}</div>
                            </div>
                            <div class='field'>
                                <div class='label'>Mensagem:</div>
                                <div class='value'>{(string.IsNullOrEmpty(model.Mensagem) ? "Nenhuma mensagem adicional" : model.Mensagem)}</div>
                            </div>
                        </div>
                        <div class='footer'>
                            Este é um email automático gerado pelo sistema de agendamento.
                        </div>
                    </div>
                </body>
                </html>";
        }
    }
}