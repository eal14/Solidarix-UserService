using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solidarix.UserService.Infrastructure.Persistence;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Detectar entorno
var env = builder.Environment.EnvironmentName;
Console.WriteLine($"Entorno actual: {env}");

// Seleccionar cadena de conexión
string? connectionString;

if (env == "Development")
{
    // Si existe variable DOCKER=true, usar Docker
    var useDocker = builder.Configuration["DOCKER"];
    connectionString = useDocker == "true"
        ? builder.Configuration.GetConnectionString("SqlServerDocker")
        : builder.Configuration.GetConnectionString("SqlServerLocal");
}
else if (env == "CI" || env == "Github")
{
    connectionString = builder.Configuration.GetConnectionString("SqlServerCI");
}
else
{
    // Producción u otros
    connectionString = builder.Configuration.GetConnectionString("SqlServerDocker");
}

// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de localización
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("es") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.MapControllers();

app.Run();
