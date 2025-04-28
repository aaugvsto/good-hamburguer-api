using GHOrderApi.Models;
using GHOrderApi.Repositories;
using GHOrderApi.Repositories.Interfaces;
using GHOrderApi.Repositories.Interfaces.Base;
using GHOrderApi.Services.Interfaces;

namespace GHOrderApi.Services
{
    public class OrderItemServices : IOrderItemService
    {
        private readonly IOrderItemRepository Repository;

        public OrderItemServices(IOrderItemRepository orderRepo)
        {
            Repository = orderRepo;
        }

        public OrderItem[] Get() => this.Repository.Get();
    }
}
