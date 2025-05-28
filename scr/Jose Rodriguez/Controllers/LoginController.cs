using System;
using Microsoft.AspNetCore.Mvc;
using LoginCadastroMVC.Models;
using SeuProjeto.Models;
using Microsoft.AspNetCore.Http;

namespace LoginCadastroMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Home/Login.cshtml", model);
            }

            var user = _db.Users.FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower());

            if (user == null || user.Password != model.Password)
            {
                Console.WriteLine("Login inválido: e-mail ou senha incorreta.");
                ModelState.AddModelError(string.Empty, "E-mail ou senha incorretos.");
                return View("~/Views/Home/Login.cshtml", model);
            }

            // Criar sessão de admin
            HttpContext.Session.SetString("AdminLogado", "true");
            HttpContext.Session.SetString("AdminNome", user.Nome);
            HttpContext.Session.SetString("AdminEmail", user.Email);

            TempData["LoginSucess"] = "Login realizado com sucesso!";
            return RedirectToAction("Painel", "Admin");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}