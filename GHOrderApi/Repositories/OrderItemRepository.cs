using GHOrderApi.Enums;
using GHOrderApi.Models;
using GHOrderApi.Repositories.Interfaces;
using GHOrderApi.Repositories.Interfaces.Base;

namespace GHOrderApi.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public OrderItem[] OrderItems { get; set; }

        public OrderItemRepository()
        {
            OrderItems = new OrderItem[]
            {
                new OrderItem(1, "X Burguer", 5m, OrderItemType.Sandwich),
                new OrderItem(2, "X Egg", 4.5m, OrderItemType.Sandwich),
                new OrderItem(3, "X Bacon", 7m, OrderItemType.Sandwich),
                new OrderItem(4, "Fries", 2m, OrderItemType.Extra, ExtraItemTag.Fries),
                new OrderItem(5, "Soft Drink", 2.5m, OrderItemType.Extra, ExtraItemTag.Soda),
            };
        }

        public OrderItem[] Get()
        {
            return this.OrderItems;
        }
    }
}
