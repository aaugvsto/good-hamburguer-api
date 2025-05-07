namespace GH.Application.DTOs
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
