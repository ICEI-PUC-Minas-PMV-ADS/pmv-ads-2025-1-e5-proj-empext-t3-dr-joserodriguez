using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LoginCadastroMVC.Models;
using SeuProjeto.Models;
using Microsoft.AspNetCore.Http;

namespace Jose_Rodriguez.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Login/Login - Exibe o formulário de login
        [HttpGet]
        public IActionResult Login()
        {
            // Se já estiver logado, redireciona para o painel
            if (HttpContext.Session.GetString("AdminLogado") == "true")
            {
                return RedirectToAction("Painel", "Admin");
            }

            // Usa o LoginViewModel se você criou, senão usa User
            return View("~/Views/Home/Login.cshtml", new User());
        }

        // ⭐ MÉTODO DE TESTE - ADICIONE ESTE MÉTODO
        [HttpGet]
        public IActionResult Test()
        {
            return Json(new
            {
                mensagem = "LoginController está funcionando!",
                hora = DateTime.Now
            });
        }

        // ⭐ MÉTODO DE TESTE POST - ADICIONE ESTE MÉTODO
        [HttpPost]
        public IActionResult TestPost()
        {
            return Json(new
            {
                mensagem = "POST está funcionando!",
                metodo = Request.Method,
                headers = Request.Headers.Count
            });
        }

        // POST: Login/Login - Processa o login
        [HttpPost]
        public IActionResult Login(User model)
        {
            try
            {
                // Limpar erros de campos que não são necessários para login
                ModelState.Remove("Nome");
                ModelState.Remove("Telefone");
                ModelState.Remove("Cedula");
                ModelState.Remove("DataCriacao");

                // Validar apenas Email e Password
                if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError(string.Empty, "Email e senha são obrigatórios.");
                    return View("~/Views/Home/Login.cshtml", model);
                }

                // Debug - Ver o que está chegando
                Console.WriteLine($"=== LOGIN DEBUG ===");
                Console.WriteLine($"Email: {model.Email}");
                Console.WriteLine($"Password: {model.Password}");

                // Buscar usuário no banco
                var user = _db.Users.FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower());

                if (user == null)
                {
                    Console.WriteLine("Usuário não encontrado!");
                    ModelState.AddModelError(string.Empty, "E-mail ou senha incorretos.");
                    return View("~/Views/Home/Login.cshtml", model);
                }

                Console.WriteLine($"Usuário encontrado: {user.Nome}");
                Console.WriteLine($"Senha do banco: {user.Password}");
                Console.WriteLine($"Senha digitada: {model.Password}");

                if (user.Password != model.Password)
                {
                    Console.WriteLine("Senha incorreta!");
                    ModelState.AddModelError(string.Empty, "E-mail ou senha incorretos.");
                    return View("~/Views/Home/Login.cshtml", model);
                }

                // Login bem-sucedido - criar sessão
                HttpContext.Session.SetString("AdminLogado", "true");
                HttpContext.Session.SetString("AdminNome", user.Nome);
                HttpContext.Session.SetString("AdminEmail", user.Email);

                TempData["LoginSuccess"] = "Login realizado com sucesso!";

                Console.WriteLine("Login bem-sucedido! Redirecionando...");
                return RedirectToAction("Painel", "Admin");
            }
            catch (Exception ex)
            {
                // Mostrar o erro específico
                Console.WriteLine($"ERRO NO LOGIN: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                ModelState.AddModelError(string.Empty, $"Erro: {ex.Message}");
                return View("~/Views/Home/Login.cshtml", model);
            }
        }

        // GET: Login/Logout
        public IActionResult Logout()
        {
            Console.WriteLine("\n=== LOGOUT ===");
            Console.WriteLine($"Usuário deslogando: {HttpContext.Session.GetString("AdminNome")}");

            HttpContext.Session.Clear();

            Console.WriteLine("Sessão limpa com sucesso!");
            Console.WriteLine("=== FIM DO LOGOUT ===\n");

            return RedirectToAction("Index", "Home");
        }
    }
}