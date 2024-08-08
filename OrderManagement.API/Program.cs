using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure.Data;
using OrderManagement.API.Services;
using OrderManagement.Application.Interfaces;
using OrderManagement.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseInMemoryDatabase("OrderManagementDB"));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
