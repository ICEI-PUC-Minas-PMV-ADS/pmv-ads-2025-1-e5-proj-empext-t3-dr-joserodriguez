using Microsoft.EntityFrameworkCore;
using LoginCadastroMVC.Models;
using SeuProjeto.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servi�o de DbContext e configura a conex�o com o banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os servi�os MVC (controladores e visualiza��es)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura o pipeline de requisi��o HTTP
if (!app.Environment.IsDevelopment())
{
    // Em ambiente de produ��o, utiliza a p�gina de erro personalizada
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS � configurado para seguran�a adicional
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite servir arquivos est�ticos (CSS, JS, imagens, etc.)

app.UseRouting();
app.UseAuthorization(); // Ativa a autoriza��o para seguran�a das rotas

// Configura as rotas do controlador
app.MapControllerRoute(
    name: "patients",  // Definindo uma rota personalizada para pacientes
    pattern: "patients/{action}/{id?}",
    defaults: new { controller = "Patient", action = "Create" });

app.MapControllerRoute(
    name: "default",  // Definindo a rota padr�o para o HomeController
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
