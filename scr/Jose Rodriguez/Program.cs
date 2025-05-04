using Microsoft.EntityFrameworkCore;
using SeuProjeto.Models; // Verifique se este � o namespace correto
using SeuProjeto.Services; // Se voc� estiver usando um servi�o de email

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servi�o de DbContext e configura a conex�o com o banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os servi�os MVC (controladores e visualiza��es)
builder.Services.AddControllersWithViews();

// Registro do servi�o EmailService (caso voc� precise injetar no seu controlador)
builder.Services.AddScoped<EmailService>();

// ADICIONE ESTAS LINHAS PARA SESS�O
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configura o pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Exibe erros detalhados no ambiente de desenvolvimento
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS � configurado para seguran�a adicional
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite servir arquivos est�ticos (CSS, JS, imagens, etc.)

app.UseRouting();

// ADICIONE ESTA LINHA PARA USAR SESS�O
app.UseSession();

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