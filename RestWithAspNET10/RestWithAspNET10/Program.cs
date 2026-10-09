using Microsoft.EntityFrameworkCore;
using RestWithAspNET10.Configurations;
using RestWithAspNET10.Context;
using RestWithAspNET10.Services;
using RestWithAspNET10.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Database Connection
builder.Services.AddDatabaseConfiguration(builder.Configuration);

//SERILOG
builder.AddSerilogLogging();

builder.Services.AddControllers();

//Injeção de Dependencia
builder.Services.AddScoped<IPersonServices, PersonServicesImplementation>();


builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
