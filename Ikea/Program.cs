

using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using NLog.Web;
using Ikea.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseNLog();

// Add services to the container.

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IRatingRepository, RatingRepository>();
builder.Services.AddTransient<IRatingService, RatingService>();

builder.Services.AddTransient<IPasswordService, PasswordService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//string connectionString = builder.Configuration.GetConnectionString("home");
string connectionString = builder.Configuration.GetConnectionString("seminar");
builder.Services.AddDbContext<IkeaContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

// Error
app.UseErrorHandlingMiddleware();

// Rating
app.UseRatingMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//404

app.Use(async (context, next) =>
{
    await next(context);
    if (context.Response.StatusCode == 404)
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync("./wwwroot/404.html");
    }
})

app.Run();