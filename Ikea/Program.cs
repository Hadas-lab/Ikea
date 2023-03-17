//Data Source=SRV2\PUPILS;Initial Catalog=Ikea;Integrated Security=True

using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IPasswordService, PasswordService>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();

builder.Services.AddDbContext<IkeaContext>(options => options.UseSqlServer("Data Source=SRV2\\PUPILS;Initial Catalog=Ikea;Integrated Security=True;"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();