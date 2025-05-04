using Microsoft.EntityFrameworkCore;
using SeuProjeto.Models; // Verifique se este é o namespace correto
using SeuProjeto.Services; // Se você estiver usando um serviço de email

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de DbContext e configura a conexão com o banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona os serviços MVC (controladores e visualizações)
builder.Services.AddControllersWithViews();

// Registro do serviço EmailService (caso você precise injetar no seu controlador)
builder.Services.AddScoped<EmailService>();

// ADICIONE ESTAS LINHAS PARA SESSÃO
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configura o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Exibe erros detalhados no ambiente de desenvolvimento
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS é configurado para segurança adicional
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite servir arquivos estáticos (CSS, JS, imagens, etc.)

app.UseRouting();

// ADICIONE ESTA LINHA PARA USAR SESSÃO
app.UseSession();

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