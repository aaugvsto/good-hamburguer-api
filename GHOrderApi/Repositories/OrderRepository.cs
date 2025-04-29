using GHOrderApi.Models;
using GHOrderApi.Repositories.Interfaces;
using GHOrderApi.Repositories.Interfaces.Base;

namespace GHOrderApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Order[] Orders { get; set; }

        public OrderRepository()
        {
            Orders = new Order[] { };
        }

        public Order Add(Order entity)
        {
            var orderId = this.Orders.Count() > 0 ? this.Orders.Max(x => x.Id) + 1 : 1;
            entity.Id = orderId;

            Orders = [.. Orders, entity];

            return entity;
        }

        public void Remove(int id)
        {
            this.Orders = [.. this.Orders.Where(x => x.Id != id)];
        }

        public Order Update(Order entity)
        {
            var index = Array.FindIndex(this.Orders, x => x.Id == entity.Id);

            if (index == -1)
                   throw new ArgumentException("Order not found");

            this.Orders[index].Amount = entity.Amount;
            this.Orders[index].Items = entity.Items;

            return this.Orders[index] = entity;
        }

        public Order[] Get()
        {
            return this.Orders;
        }
    }
}
