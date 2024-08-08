using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrderAsync()
        {
            var order = new Order();
            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task AddProductToOrderAsync(int orderId, Product product)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null || order.IsClosed)
            {
                throw new InvalidOperationException("Cannot add products to a closed or non-existent order.");
            }

            order.AddProduct(product);
            await _orderRepository.UpdateAsync(order);
        }

        public async Task RemoveProductFromOrderAsync(int orderId, int productId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null || order.IsClosed)
            {
                throw new InvalidOperationException("Cannot remove products from a closed or non-existent order.");
            }

            var product = order.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                order.RemoveProduct(product);
                await _orderRepository.UpdateAsync(order);
            }
        }

        public async Task CloseOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new InvalidOperationException("Order does not exist.");
            }

            if (!order.Products.Any())
            {
                throw new InvalidOperationException("Cannot close an order with no products.");
            }

            order.CloseOrder();
            await _orderRepository.UpdateAsync(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(bool? isClosed = null)
        {
            return await _orderRepository.GetAllAsync(isClosed);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetByIdAsync(orderId);
        }
    }
}