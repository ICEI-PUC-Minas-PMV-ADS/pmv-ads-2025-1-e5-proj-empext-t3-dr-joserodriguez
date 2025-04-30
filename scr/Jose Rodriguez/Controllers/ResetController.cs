using System;
using Microsoft.AspNetCore.Mvc;
using LoginCadastroMVC.Models;
using SeuProjeto.Models;

namespace Jose_Rodriguez.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ResetPasswordController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendResetLink(User model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Home/RedefinirSenha.cshtml", model);
            }

            var user = _db.Users.FirstOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "E-mail não encontrado.");
                return View("~/Views/Home/RedefinirSenha.cshtml", model);
            }

            var token = Guid.NewGuid().ToString();
            new EmailService().EnviarResetSenha(user.Email, token);

            ViewBag.ResetLinkSent = "Link de redefinição enviado para o seu e-mail.";
            ModelState.Clear();
            return View("~/Views/Home/RedefinirSenha.cshtml", new User());
        }
    }
}
