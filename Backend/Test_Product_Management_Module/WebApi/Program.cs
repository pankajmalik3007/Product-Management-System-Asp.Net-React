using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services.Custome.CartServices;
using Infrastructure.Services.Custome.CategoryServices;
using Infrastructure.Services.Custome.OrderItemservices;
using Infrastructure.Services.Custome.OrderServices;
using Infrastructure.Services.Custome.ProductServices;
using Infrastructure.Services.Custome.ProductServices.Infrastructure.Services.Custom.CourseServices;
using Infrastructure.Services.General;
using Infrastructure.Services.Generic;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient(typeof(ICategoryService), typeof(CategoryServices));
builder.Services.AddTransient(typeof(IProductService), typeof(ProductService));
builder.Services.AddTransient(typeof(ICartService), typeof(CartService));
builder.Services.AddTransient(typeof(IOrderItemService), typeof(OrderItemService));
builder.Services.AddTransient(typeof(IOrderService), typeof(OrderService));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
