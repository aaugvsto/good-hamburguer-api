namespace GHOrderApi.Records.DTOs
{
    public record CreateOrderDTO
    {
        public CreateOrderDTO()
        {
            Items = [];
        }

        public int[] Items { get; set; }
    }
}
