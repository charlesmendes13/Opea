using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Opea.Application.AutoMapper;
using Opea.Domain.Exceptions;
using Opea.Infrastructure.Data.Context;
using Opea.Infrastructure.IoC;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Context

builder.Services.AddDbContext<OpeaContext>(option =>
     option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"))
);

// MediatR

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// IoC

InjectorDependency.Register(builder.Services);

// AutoMapper

builder.Services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile), typeof(DomainToViewModelMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseExceptionHandler(options => 
    {
        options.Run(async context => 
        {
            context.Response.ContentType = "text/html";

            var exception = context.Features.Get<IExceptionHandlerFeature>();
            var response = context.Response;

            switch (exception)
            {
                case DomainException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.Redirect($"/Home/Error?statusCode={response.StatusCode}&message={exception.Error.Message}");

            await Task.CompletedTask;
        });    
    }); 
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
