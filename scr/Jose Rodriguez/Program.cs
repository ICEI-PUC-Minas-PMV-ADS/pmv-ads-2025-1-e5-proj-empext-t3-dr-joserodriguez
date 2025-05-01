using Microsoft.EntityFrameworkCore;
using LoginCadastroMVC.Models; // Verifique se este � o namespace correto
using SeuProjeto.Models; // Verifique se este � o namespace correto

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
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS � configurado para seguran�a adicional
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite servir arquivos est�ticos (CSS, JS, imagens, etc.)

app.UseRouting();
app.UseAuthorization(); // Ativa a autoriza��o para seguran�a das rotas

// Rota personalizada para pacientes
app.MapControllerRoute(
    name: "patients",  // Definindo uma rota personalizada para pacientes
    pattern: "patients/{action}/{id?}",
    defaults: new { controller = "Patient", action = "Create" });

// Rota personalizada para o AgendamentosController
app.MapControllerRoute(
    name: "agendamentos",  // Rota para o AgendamentosController
    pattern: "Agendamentos/{action=Index}/{id?}",  // Definindo o padr�o de rota
    defaults: new { controller = "Agendamentos", action = "Index" });  // Controller e a��o padr�o

// Rota padr�o para o HomeController
app.MapControllerRoute(
    name: "default",  // Rota padr�o
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia a aplica��o
app.Run();
