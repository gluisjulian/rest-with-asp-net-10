using RestWithAspNET10.Configurations;
using RestWithAspNET10.Repositories;
using RestWithAspNET10.Repositories.Implementation;
using RestWithAspNET10.Services;
using RestWithAspNET10.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

//SERILOG
builder.AddSerilogLogging();

builder.Services.AddControllers();

// Database Connection
builder.Services.AddDatabaseConfiguration(builder.Configuration);

//Evolve
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

//Injeção de Dependencia
builder.Services.AddScoped<IPersonServices, PersonServicesImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IBookService, BookServiceImplementation>();
builder.Services.AddScoped<IBookRepository, BookRepository>();


//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
