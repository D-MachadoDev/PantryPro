
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PantryPro.Core.Interfaces;
using PantryPro.Infrastructure.Data;
using PantryPro.Web.Mapping;
using PantryPro.Infrastructure.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Configurar Serilog (Mensajes de errores y depuración, mas qeu todo testear)
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .CreateLogger();

// Usar Serilog como el logger del host
builder.Host.UseSerilog();

// Base de datos
builder.Services.AddDbContext<PantryProDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// Inyección de dependencias
builder.Services.AddScoped<IUserService, UserService>();

// MVC.
builder.Services.AddControllersWithViews();

// Httpclient configuration for external APIs
builder.Services.AddHttpClient("Spoonacular", c =>
{
    c.BaseAddress = new Uri(configuration["ExternalAPIs:Spoonacular:BaseUrl"]);
    c.DefaultRequestHeaders.Add("X-Api-Key", configuration["ExternalAPIs:Spoonacular:ApiKey"]);
});

// Mememoria Radis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration.GetConnectionString("Redis");
});


var app = builder.Build();

// Middleware configuration
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
