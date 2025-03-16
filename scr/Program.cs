using Microsoft.EntityFrameworkCore;
using LoginCadastroMVC.Models;
using SeuProjeto.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de DbContext e configura a conexão com o banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os serviços MVC (controladores e visualizações)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura o pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    // Em ambiente de produção, utiliza a página de erro personalizada
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS é configurado para segurança adicional
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite servir arquivos estáticos (CSS, JS, imagens, etc.)

app.UseRouting();
app.UseAuthorization(); // Ativa a autorização para segurança das rotas

// Configura as rotas do controlador
app.MapControllerRoute(
    name: "patients",  // Definindo uma rota personalizada para pacientes
    pattern: "patients/{action}/{id?}",
    defaults: new { controller = "Patient", action = "Create" });

app.MapControllerRoute(
    name: "default",  // Definindo a rota padrão para o HomeController
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
