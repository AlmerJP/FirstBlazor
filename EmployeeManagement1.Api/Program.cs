using EmployeeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Security;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// KANSKE INTE FUNGERAR:
// Problem från denna video (8:50) h ttps://www.youtube.com/watch?v=J7Ho7HS7i_Y&list=PL6n9fhu94yhVowClAs8-6nYnfsOTma14P&index=12 

builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(GetConnectionString("DBConnection")));

Action<SqlServerDbContextOptionsBuilder>? GetConnectionString(string v)
{
    throw new NotImplementedException();
}

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
