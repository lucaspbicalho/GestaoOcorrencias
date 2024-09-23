using GestaoOcorrencias.Api;
using GestaoOcorrencias.Api.Configuration;
using GestaoOcorrencias.Infrastructure.Repositories;
using GestaoOcorrencias.Services.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

// Repository
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
// Services
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<OcorrenciaService>();


var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<DataContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
