using Jose_Rodriguez.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jose_Rodriguez.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Location()
        {
            return View();
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
