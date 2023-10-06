using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the DbContext service.
builder.Services.AddDbContext<MyDBContext>(options => options.UseMySql("Server=msproducts.mysql.database.azure.com;Database=msproducts;User=salman;Password=Abc12345;", new MySqlServerVersion(new Version(8, 0, 11))));

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
