using MediatR;
using Microsoft.EntityFrameworkCore;
using Opea.Application.AutoMapper;
using Opea.Application.Middlewares;
using Opea.Infrastructure.Data.Context;
using Opea.Infrastructure.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Context

builder.Services.AddDbContext<OpeaContext>(option =>
     option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"))
);

// MediatR

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// IoC

InjectorDependency.Register(builder.Services);

// AutoMapper

builder.Services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile), typeof(DomainToViewModelMappingProfile));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
