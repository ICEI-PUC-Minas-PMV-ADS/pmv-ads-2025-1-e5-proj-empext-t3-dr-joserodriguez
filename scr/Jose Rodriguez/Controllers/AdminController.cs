using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Jose_Rodriguez.Controllers
{
    public class AdminController : Controller
    {
        private bool IsAdminLogado()
        {
            return HttpContext.Session.GetString("AdminLogado") == "true";
        }

        public IActionResult Painel()
        {
            if (!IsAdminLogado())
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.AdminNome = HttpContext.Session.GetString("AdminNome");
            return View();
        }

        public IActionResult CadastrarPaciente()
        {
            if (!IsAdminLogado())
            {
                return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("Create", "Patient");
        }

        public IActionResult AlterarCadastroPaciente()
        {
            if (!IsAdminLogado())
            {
                return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("Management", "Patient");
        }

        public IActionResult CadastrarDentista()
        {
            if (!IsAdminLogado())
            {
                return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("Create", "Dentistas");
        }

        public IActionResult AlterarCadastroDentista()
        {
            if (!IsAdminLogado())
            {
                return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("Index", "Dentistas");
        }

        public IActionResult GerenciamentoAgenda()
        {
            if (!IsAdminLogado())
            {
                return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("Index", "Agendamentos");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}