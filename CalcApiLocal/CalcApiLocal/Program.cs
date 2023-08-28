using CalcApiLocal.Data;
using CalcApiLocal.Interface;
using CalcApiLocal.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CalcContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddTransient<ICalc, CalcRepos>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
