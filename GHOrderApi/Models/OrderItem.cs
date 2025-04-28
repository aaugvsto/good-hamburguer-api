using GHOrderApi.Enums;

namespace GHOrderApi.Models
{
    public class OrderItem
    {
        public OrderItem()
        {

        }

        public OrderItem(int id, string name, decimal price, OrderItemType type, ExtraItemTag? extraItemTag = null)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Type = Type;

            if(type == OrderItemType.Extra)
            {
                if(extraItemTag is null)
                    throw new ArgumentNullException(nameof(extraItemTag), "Extra item must have a tag.");

                this.ExtraItemTag = extraItemTag;
            }
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public OrderItemType Type { get; private set; }
        public ExtraItemTag? ExtraItemTag { get; private set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price:0:N}, Type: {Type}";
        }
    }
}
