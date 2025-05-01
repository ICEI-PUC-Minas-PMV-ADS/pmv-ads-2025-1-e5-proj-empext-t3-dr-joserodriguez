using Microsoft.AspNetCore.Mvc;
using SeuProjeto.Models;  // Verifique se o namespace está correto

namespace SeuProjeto.Controllers
{
    public class AgendamentosController : Controller
    {
        // Ação para exibir o formulário de agendamento
        public IActionResult Index()
        {
            return View();
        }

        // Ação para processar o agendamento (caso precise)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Enviar(AgendamentoViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            // Lógica do envio de e-mail ou outro processo

            return View("Index");
        }
    }
}
