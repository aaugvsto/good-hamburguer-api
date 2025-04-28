using System.ComponentModel.DataAnnotations;
using GHOrderApi.Enums;
using GHOrderApi.Models;
using GHOrderApi.Records;
using GHOrderApi.Repositories;
using GHOrderApi.Repositories.Interfaces;
using GHOrderApi.Repositories.Interfaces.Base;
using GHOrderApi.Services.Interfaces;

namespace GHOrderApi.Services
{
    public class OrderServices : IOrderService
    {
        private readonly IOrderRepository Repository;
        private readonly IOrderItemRepository OrderItemRepository;

        public OrderServices(IOrderRepository orderRepo, IOrderItemRepository orderItemRepository)
        {
            Repository = orderRepo;
            OrderItemRepository = orderItemRepository;
        }

        public Order Add(Order entity)
        {
            if(!entity.Items.Any())
                throw new ValidationException("Order must have at least one item.");

            var orderItems = OrderItemRepository.Get();
            var items = orderItems.Where(x => entity.Items.Contains(x.Id));

            if(items.Where(x => x.Type == OrderItemType.Sandwich).Count() > 1)
                throw new ValidationException("Order can only have one sandwich.");

            entity.Total = CalculateOrderTotalValue(items);

            return Repository.Add(entity);
        }

        public Order[] Get() => Repository.Get();

        public void Remove(int id)
        {
            Repository.Remove(id);
        }

        public Order Update(Order entity)
        {
            return Repository.Update(entity);
        }

        #region Private Methods

        private static decimal CalculateOrderTotalValue(IEnumerable<Models.OrderItem> items)
        {
            var hasSandwich = false;
            var hasFries = false;
            var hasSoftDrink = false;

            foreach (var item in items)
            {
                if (hasSandwich && hasFries && hasSoftDrink)
                    break;

                if (item.Type == OrderItemType.Sandwich)
                    hasSandwich = true;
                else if (item.Type == OrderItemType.Extra)
                    hasFries = true;
                else if (item.Type == OrderItemType.Extra && item.Name.Equals("Soft Drink", StringComparison.OrdinalIgnoreCase))
                    hasSoftDrink = true;
            }

            decimal subTotal = items.Sum(x => x.Price);
            decimal discount = 0m;

            if (hasSandwich && hasFries && hasSoftDrink)
                discount = subTotal * 0.2m;
            else if (hasSandwich && hasSoftDrink)
                discount = subTotal * 0.15m;
            else if (hasSandwich && hasFries)
                discount = subTotal * 0.1m;

            decimal total = subTotal - discount;

            return total;
        }

        #endregion
    }
}
