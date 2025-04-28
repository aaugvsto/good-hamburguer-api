namespace GHOrderApi.Models
{
    public class Order(int Id, int[] Items, decimal Total)
    {
        public int Id { get; set; } = Id;
        public int[] Items { get; set; } = Items;
        public decimal Total { get; set; } = Total;
    }
}
