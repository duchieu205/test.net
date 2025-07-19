using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure;
using OrderManagement.Domain.Interfaces;
using MediatR;
using FluentValidation;
using OrderManagement.Application.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseMySql(builder.Configuration.GetConnectionString("Default"),
        new MySqlServerVersion(new Version(8, 0, 36))));

builder.Services.AddScoped<ProductRepositoryInterface, ProductRepository>();
builder.Services.AddScoped<OrderRepositoryInterface, OrderRepository>();


builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateProductHandler>());


builder.Services.AddValidatorsFromAssemblyContaining<CreateProductHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
