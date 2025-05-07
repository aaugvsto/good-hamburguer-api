using GH.Domain.Entities;
using GH.Domain.Interfaces.Repositories;
using GH.Domain.Interfaces.Services;

namespace GH.Application.Services
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
