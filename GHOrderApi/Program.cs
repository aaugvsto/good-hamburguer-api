using GHOrderApi.Enums;
using GHOrderApi.Records.DTOs;
using Microsoft.AspNetCore.Mvc;
using GHOrderApi.Infra;
using GHOrderApi.Services.Interfaces;
using GHOrderApi.Models;

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

app.MapGet("api/orderitem/type/sandwich", (IOrderItemService service) =>
{
    var response = service.Get().Where(x => x.Type == OrderItemType.Sandwich);
    return Results.Ok(response);
})
.WithName("GetOrderItemsTypeSandwich")
.WithOpenApi();


app.MapGet("api/orderitem/type/extra", (IOrderItemService service) =>
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

app.MapPost("api/order", ([FromBody] CreateOrderDTO dto) =>
{
    if(dto.Items.Length == 0)
        return Results.BadRequest("Order must have at least one item.");

    var order = new Order(1, dto.Items);

    return Results.Ok(order);
})
.WithName("AddGetOrders")
.WithOpenApi();

app.MapPatch("api/order/", (Order dto, IOrderService service) =>
{
    var orderUpdated = service.Update(dto);
    return Results.Ok(orderUpdated);
})
.WithName("UpdateOrder")
.WithOpenApi();

app.MapDelete("api/order/{id}", (int id, IOrderService service) =>
{
    service.Remove(id);
    return Results.NoContent();
})
.WithName("RemoveOrder")
.WithOpenApi();

app.Run();