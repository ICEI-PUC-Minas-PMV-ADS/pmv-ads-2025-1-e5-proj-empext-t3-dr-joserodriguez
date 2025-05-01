using Jose_Rodriguez.Models;
using SeuProjeto.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jose_Rodriguez.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailService _emailService;

        public HomeController(ILogger<HomeController> logger, EmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }   

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Location(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string corpo = $@"
                <p><strong>Nome:</strong> {model.Nome}</p>
                <p><strong>Email:</strong> {model.Email}</p>
                <p><strong>Mensagem:</strong><br>{model.Mensagem}</p>
            ";

                    await _emailService.EnviarEmailAsync("medepermissao@gmail.com", "Mensagem do site", corpo); // Mudar Destinatário para teste. Oficial (consultoriodontovip@gmail.com)

                    ViewBag.MensagemEnviada = true;
                }
                catch
                {
                    ViewBag.Erro = true;
                }
            }

            return View(model);
        }


        public IActionResult Depoimentos()
        {
            return View();
        }
        public IActionResult RedefinirSenha()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Antes_depois()
        {
            return View();
        }
        public IActionResult Historia()
        {
            return View();
        }
        public IActionResult Tela_home()
        {
            return View();
        }
        public IActionResult Management()
        {
            return View("~/Views/Patient/Management.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
