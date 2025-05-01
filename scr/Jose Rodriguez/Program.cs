using Microsoft.EntityFrameworkCore;
using LoginCadastroMVC.Models; // Verifique se este é o namespace correto
using SeuProjeto.Models; // Verifique se este é o namespace correto

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
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS é configurado para segurança adicional
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite servir arquivos estáticos (CSS, JS, imagens, etc.)

app.UseRouting();
app.UseAuthorization(); // Ativa a autorização para segurança das rotas

// Rota personalizada para pacientes
app.MapControllerRoute(
    name: "patients",  // Definindo uma rota personalizada para pacientes
    pattern: "patients/{action}/{id?}",
    defaults: new { controller = "Patient", action = "Create" });

// Rota personalizada para o AgendamentosController
app.MapControllerRoute(
    name: "agendamentos",  // Rota para o AgendamentosController
    pattern: "Agendamentos/{action=Index}/{id?}",  // Definindo o padrão de rota
    defaults: new { controller = "Agendamentos", action = "Index" });  // Controller e ação padrão

// Rota padrão para o HomeController
app.MapControllerRoute(
    name: "default",  // Rota padrão
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia a aplicação
app.Run();
