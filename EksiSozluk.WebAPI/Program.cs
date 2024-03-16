using Autofac;
using Autofac.Extensions.DependencyInjection;
using EksiSozluk.Application.Service;
using EksiSozluk.Persistence.Context;
using EksiSozluk.WebAPI.IOC.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EksiSozluk.Persistence.Context.DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbUrl")
    ));
// Add db context db context türünden parametre istiyor Domain içerisinde kalýtým aldýðýmýz
//db context dolaylý yoldan db oluyor getconnection string içerisinde yazdýðýmýz dburl 
// bizim appsettingsten geldi

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("EksiSozukCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddApplicationService(builder.Configuration);

builder.Host.ConfigureContainer<ContainerBuilder>(
   builder => builder.RegisterModule(new AutofacAPIModule()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseCors("CarBookCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
