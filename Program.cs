using Microsoft.AspNetCore.Builder; // Certifique-se de que este using existe
using Microsoft.Extensions.DependencyInjection; // Certifique-se de que este using existe
using Microsoft.Extensions.Hosting; // Certifique-se de que este using existe
using System; // Para TimeSpan

var builder = WebApplication.CreateBuilder(args);

//Adicionar serviços ao contêiner.
//Este bloco 'builder.Services' é para registrar serviços que o app usará.
builder.Services.AddControllersWithViews();

// Adicione isso para usar a sessão
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Define o tempo limite da sessão
    options.Cookie.HttpOnly = true; // Impede acesso via JavaScript (segurança)
    options.Cookie.IsEssential = true; // Garante que a sessão seja essencial para a funcionalidade do app
});

var app = builder.Build();

//Configurar o pipeline de requisições HTTP.
//'app.Use' é para definir a ordem em que os middlewares processam as requisições.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redireciona HTTP para HTTPS
app.UseStaticFiles();     // Permite servir arquivos estáticos (CSS, JS, imagens na wwwroot)

app.UseRouting();         // <-- IMPORTANTE: UseRouting DEVE VIR ANTES de UseSession e UseAuthorization

app.UseSession();         // <-- IMPORTANTE: UseSession DEVE VIR DEPOIS de UseRouting

app.UseAuthorization();   // (Opcional, mas geralmente depois de UseSession se usar dados de sessão para autorização)

// Onde as rotas do MVC são mapeadas.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();