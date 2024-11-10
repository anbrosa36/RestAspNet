using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using RestApplication.Business;
using RestApplication.Business.Implematations;
using RestApplication.Hypermedia.Enricher;
using RestApplication.Hypermedia.Filters;
using RestApplication.Model.Context;
using RestApplication.Repository;
using RestApplication.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => options.AddDefaultPolicy(b =>
    b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
));

builder.Services.AddControllers();

//Connection Data Base
var connection = builder.Configuration["BancoConexao:ConnectionString"];
builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer(connection));

//Serealização XML e Json
builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
    
}).AddXmlSerializerFormatters();


//Implementação de HATEOAS
var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

builder.Services.AddSingleton(filterOptions);

//Versioning Api
builder.Services.AddApiVersioning();

// Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute("DefaultApi", "{controller=values}/v{version=apiVersion}/{id?}");

app.Run();
