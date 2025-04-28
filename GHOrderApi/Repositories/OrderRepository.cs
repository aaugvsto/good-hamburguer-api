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
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order[] Get()
        {
            throw new NotImplementedException();
        }
    }
}
