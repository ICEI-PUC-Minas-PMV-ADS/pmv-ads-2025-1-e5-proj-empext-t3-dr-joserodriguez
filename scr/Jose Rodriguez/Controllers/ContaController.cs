using SeuProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using SeuProjeto.Services;
using Microsoft.EntityFrameworkCore;
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

        var usuario = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == model.Email);

        if (usuario == null)
        {
            ViewBag.ResetLinkSent = "E-mail incorreto ou não cadastrado.";
            ViewBag.ResetLinkClass = "alert-danger";
            return View(model);
        }

        var resetLink = Url.Action("NovaSenha", "Conta", new { email = model.Email }, Request.Scheme);

        var corpoEmail = $@"
        <p>Olá,</p>

        <p>Recebemos uma solicitação para redefinir a sua senha. Para prosseguir, clique no link abaixo:</p>

        <p><a href='{resetLink}'>Redefinir Senha</a></p>

        <p>Se você não solicitou essa alteração, pode ignorar este e-mail com segurança. Sua senha permanecerá inalterada.</p>

        <p>Atenciosamente,<br/>Equipe [Nome da Empresa]</p>";

        await _emailService.EnviarEmailAsync(model.Email, "Redefinição de Senha", corpoEmail);

        ViewBag.ResetLinkSent = "Um link foi enviado para o e-mail informado.";
        ViewBag.ResetLinkClass = "alert-success";

        return View();
    }

    [HttpGet]
    public IActionResult NovaSenha(string email)
    {
        var model = new NovaSenhaViewModel { Email = email };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> NovaSenha(NovaSenhaViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var usuario = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == model.Email);

        if (usuario == null)
        {
            ModelState.AddModelError("", "Usuário não encontrado.");
            return View(model);
        }

        usuario.Password = model.Senha; // Em produção, aplicar hashing!

        _context.Update(usuario);
        await _context.SaveChangesAsync();

        TempData["Mensagem"] = "Senha atualizada com sucesso!";
        return Redirect("/Home/Login");
    }
}