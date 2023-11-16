using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingComplex.Application.Configs;
using ShoppingComplex.Infrastructure.Configs;
using ShoppingComplex.Infrastructure.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add application Layer Dependency Injections
builder.Services.AddApplicationDependencyGroup();

// Add infrastructure Layer Dependency Injection
builder.Services.AddInfrastructureDependencyGroup();

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddControllers();
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
