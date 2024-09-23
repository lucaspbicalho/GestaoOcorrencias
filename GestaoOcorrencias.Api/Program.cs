using GestaoOcorrencias.Api;
using GestaoOcorrencias.Api.Configuration;
using GestaoOcorrencias.Infrastructure.Repositories;
using GestaoOcorrencias.Services.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.

builder.Services.AddControllers();

// Repository
builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();
builder.Services.AddSingleton<IOcorrenciaRepository, OcorrenciaRepository>();
// Services
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<OcorrenciaService>();

builder.Services.AddDbContext<GestaoOcorrencias.Infrastructure.Contexts.EntityContext>();



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GestaoOcorrencias.Infrastructure.Contexts.EntityContext>();
}
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
