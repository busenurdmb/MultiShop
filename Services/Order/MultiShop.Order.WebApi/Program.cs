using MultiShop.Order.Application;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Create;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Delete;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Update;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetById;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetList;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Create;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Delete;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Update;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetById;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetList;
using MultiShop.Order.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);




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
