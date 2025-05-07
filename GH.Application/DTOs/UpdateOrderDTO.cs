namespace GH.Application.DTOs
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
