using System.Text.Json.Serialization;

namespace GH.Domain.Entities
{
    public class Order
    {
        public Order()
        {
        }

        public Order(int id, OrderItem[] items, decimal amount)
        {
            this.Id = id;
            this.Items = items;
            this.Amount = amount;
        }

        public Order(OrderItem[] items)
        {
            this.Items = items;
        }

        public int Id { get; set; }
        public OrderItem[] Items { get; set; }
        public decimal Amount { get; set; }

        [JsonIgnore]
        public int[] ItemsIds { get; set; }
    }
}
