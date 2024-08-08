namespace OrderManagement.API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public bool IsClosed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}