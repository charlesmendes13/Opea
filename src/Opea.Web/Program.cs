using MediatR;
using Microsoft.EntityFrameworkCore;
using Opea.Application.AutoMapper;
using Opea.Infrastructure.Data.Context;
using Opea.Infrastructure.IoC;
using System.Net.NetworkInformation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Context

builder.Services.AddDbContext<OpeaContext>(option =>
     option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"))
);

// MediatR

builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));

// IoC

InjectorDependency.Register(builder.Services);

// AutoMapper

builder.Services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile), typeof(DomainToViewModelMappingProfile));

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
