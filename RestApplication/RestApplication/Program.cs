using Microsoft.EntityFrameworkCore;
using RestApplication.Model.Context;
using RestApplication.Services;
using RestApplication.Services.Implematations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["BancoConexao:ConnectionString"];
builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer(connection));

// Dependency Injection
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

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
