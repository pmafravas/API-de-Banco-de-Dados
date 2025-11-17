using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning) // Reduz o "ruído" do ASP.NET Core
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails() // Vem do Serilog.Exceptions
    .WriteTo.Console()
    .WriteTo.File(
        "logs/Error" + DateTime.Today.ToString() + ".log", // Caminho do arquivo
        rollingInterval: RollingInterval.Minute, // Cria um novo arquivo todo minuto
        restrictedToMinimumLevel: LogEventLevel.Warning, // Nível mínimo para este sink
        outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}") // Template
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();