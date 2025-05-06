using System.ComponentModel.DataAnnotations;
using GH.Domain.Entities;
using GH.Domain.Enums;
using GH.Domain.Interfaces.Repositories;
using GH.Domain.Interfaces.Services;

namespace GH.Application.Services
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
            if(!entity.ItemsIds.Any())
                throw new ValidationException("Order must have at least one item.");

            var orderItems = OrderItemRepository.Get();
            var items = orderItems.Where(x => entity.ItemsIds.Contains(x.Id)).ToArray();

            if (items.Where(x => x.Type == OrderItemType.Sandwich).Count() > 1)
                throw new ValidationException("An order can only contain one sandwich.");

            if (items.Where(x => x.Type == OrderItemType.Extra && x.ExtraItemTag == ExtraItemTag.Fries).Count() > 1)
                throw new ValidationException("An order can only contain one fries.");

            if (items.Where(x => x.Type == OrderItemType.Extra && x.ExtraItemTag == ExtraItemTag.Soda).Count() > 1)
                throw new ValidationException("You can only pick one soda per order.");

            entity.Amount = CalculateOrderAmount(items);
            entity.Items = items;

            return Repository.Add(entity);
        }

        public Order[] Get() => Repository.Get();

        public void Remove(int id)
        {
            Repository.Remove(id);
        }

        public Order Update(Order entity)
        {
            var orderItems = this.OrderItemRepository.Get().Where(x => entity.ItemsIds.Contains(x.Id)).ToArray();

            if (!orderItems.Any())
                throw new ValidationException("Order must have at least one item.");

            entity.Items = orderItems;
            entity.Amount = CalculateOrderAmount(orderItems);

            return Repository.Update(entity);
        }

        #region Private Methods

        private static decimal CalculateOrderAmount(IList<OrderItem> items)
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
                else if (item.Type == OrderItemType.Extra && item.ExtraItemTag == ExtraItemTag.Fries)
                    hasFries = true;
                else if (item.Type == OrderItemType.Extra && item.ExtraItemTag == ExtraItemTag.Soda)
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
