using Microsoft.EntityFrameworkCore;
using RestApplication.Model.Context;
using RestApplication.Business;
using RestApplication.Business.Implematations;
using RestApplication.Repository;
using RestApplication.Repository.Implematations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Connection Data Base
var connection = builder.Configuration["BancoConexao:ConnectionString"];
builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer(connection));

//Versioning Api
builder.Services.AddApiVersioning();

// Dependency Injection
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

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
