using SeuProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using SeuProjeto.Services;
using Microsoft.EntityFrameworkCore; // necessário para AnyAsync
using System.Threading.Tasks;

public class ContaController : Controller
{
    private readonly EmailService _emailService;
    private readonly ApplicationDbContext _context;

    public ContaController(EmailService emailService, ApplicationDbContext context)
    {
        _emailService = emailService;
        _context = context;
    }

    [HttpGet]
    public IActionResult RedefinirSenha()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RedefinirSenha(RedefinirSenhaViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var usuarioExiste = await _context.Users.AnyAsync(u => u.Email == model.Email);

        if (usuarioExiste)
        {
            var resetLink = Url.Action("NovaSenha", "Conta", new { email = model.Email }, Request.Scheme);
            var corpoEmail = $"Clique no link para redefinir sua senha: <a href='{resetLink}'>Redefinir Senha</a>";

#pragma warning disable CS8604
            await _emailService.EnviarEmailAsync(model.Email, "Redefinição de Senha", corpoEmail);
#pragma warning restore CS8604

            ViewBag.ResetLinkSent = "Um link foi enviado para o seu e-mail.";
            ViewBag.ResetLinkClass = "alert-success";
        }
        else
        {
            ViewBag.ResetLinkSent = "E-mail incorreto ou não cadastrado.";
            ViewBag.ResetLinkClass = "alert-danger";
        }

        return View();
    }
}