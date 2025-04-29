namespace GHOrderApi.Records.DTOs
{
    public record UpdateOrderDTO
    {
        public UpdateOrderDTO()
        {
            Items = [];
        }

        public int[] Items { get; set; }
    }
}
