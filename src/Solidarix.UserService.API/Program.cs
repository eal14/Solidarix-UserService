using Solidarix.UserService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
