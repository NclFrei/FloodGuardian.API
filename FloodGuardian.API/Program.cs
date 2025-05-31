using FloodGuardian.Application.Service;
using FloodGuardian.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext
builder.Services.AddDbContext<FloodGuardianContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // só precisa uma vez
builder.Services.AddSwaggerGen();

// Serviços da aplicação
builder.Services.AddScoped<UserService>(); // se tiver interface
// builder.Services.AddScoped<UserService>(); // se estiver sem interface, ainda funciona

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
