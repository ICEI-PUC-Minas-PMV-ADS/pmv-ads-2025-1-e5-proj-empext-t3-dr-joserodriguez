using System;
using Microsoft.AspNetCore.Mvc;
using LoginCadastroMVC.Models;
using SeuProjeto.Models;

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

            var user = _db.Users.FirstOrDefault(u => u.Email == model.Email);

            if (user == null || user.Password != model.Password)
            {
                Console.WriteLine("Login inválido: e-mail ou senha incorreta.");
                ModelState.AddModelError(string.Empty, "E-mail ou senha incorretos.");
                return View("~/Views/Home/Login.cshtml", model);
            }

            TempData["LoginSucess"] = "Login realizado com sucesso!";
            return RedirectToAction("Index", "Home");
        }
    }
}
