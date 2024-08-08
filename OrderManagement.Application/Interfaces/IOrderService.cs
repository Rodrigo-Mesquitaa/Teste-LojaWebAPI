using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync();
        Task AddProductToOrderAsync(int orderId, Product product);
        Task RemoveProductFromOrderAsync(int orderId, int productId);
        Task CloseOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync(bool? isClosed = null);
        Task<Order> GetOrderByIdAsync(int orderId);
    }
}
