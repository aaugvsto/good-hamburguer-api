using GH.Application.DTOs;
using GH.Domain.Entities;
using GH.Domain.Enums;
using GH.Domain.Interfaces.Services;
using GH.WebAPI.Configurations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/orderitem", (IOrderItemService service) =>
{
    return service.Get();
})
.WithName("GetOrderItems")
.WithOpenApi();

app.MapGet("api/orderitem/sandwich", (IOrderItemService service) =>
{
    var response = service.Get().Where(x => x.Type == OrderItemType.Sandwich);
    return Results.Ok(response);
})
.WithName("GetOrderItemsTypeSandwich")
.WithOpenApi();


app.MapGet("api/orderitem/extra", (IOrderItemService service) =>
{
    var response = service.Get().Where(x => x.Type == OrderItemType.Extra);
    return Results.Ok(response);
})
.WithName("GetOrderItemsTypeExtra")
.WithOpenApi();

app.MapGet("api/order", (IOrderService service) =>
{
    return Results.Ok(service.Get());
})
.WithName("GetOrders")
.WithOpenApi();

app.MapPost("api/order", ([FromBody] CreateOrderDTO dto, IOrderService service) =>
{
    try
    {
        var order = new Order();

        order.ItemsIds = dto.Items;

        service.Add(order);

        return Results.Created($"api/order/{order.Id}", new { order.Amount });
    }
    catch(ValidationException ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.WithName("AddGetOrders")
.WithOpenApi();

app.MapPut("api/order/{id}", (int id, [FromBody] UpdateOrderDTO dto, IOrderService service) =>
{
    try
    {
        var order = service.Get().FirstOrDefault(x => x.Id == id);

        if (order is null)
            return Results.NotFound();

        order.ItemsIds = dto.Items;

        var orderUpdated = service.Update(order);

        return Results.Ok(orderUpdated);
    }
    catch (ValidationException ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.WithName("UpdateOrder")
.WithOpenApi();

app.MapDelete("api/order/{id}", (int id, IOrderService service) =>
{
    if (!service.Get().Any(x => x.Id == id))
        return Results.NotFound();

    service.Remove(id);

    return Results.NoContent();
})
.WithName("RemoveOrder")
.WithOpenApi();

app.Run();