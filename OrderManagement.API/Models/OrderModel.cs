namespace OrderManagement.API.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public bool IsClosed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}