using Autofac;
using Autofac.Extensions.DependencyInjection;
using EksiSozluk.Application.Service;
using EksiSozluk.Persistence.Context;
using EksiSozluk.WebAPI.IOC.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CarBook.WebAPI.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllersWithViews().
    AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        opt.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add db context db context t�r�nden parametre istiyor Domain i�erisinde kal�t�m ald���m�z
//db context dolayl� yoldan db oluyor getconnection string i�erisinde yazd���m�z dburl 
// bizim appsettingsten geldi
builder.Services.AddDbContext<EksiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbUrl"));
});

//Creating Identity Extension 
//Add identity
builder.Services.AddIdentityEx();

//Config Identity
builder.Services.ConfigIdentityEx();

//Add authentication and JwtBearer
builder.Services.AddAuthAndJwtBearerEx(builder.Configuration);

//Add Cors
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("EksiSozukCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddApplicationService();

builder.Host.ConfigureContainer<ContainerBuilder>(
    builder => builder.RegisterModule(new AutofacAPIModule()));
//autofac implementation


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseCors("EksiSozukCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
