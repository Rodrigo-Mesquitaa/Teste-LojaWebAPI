using Moq;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Entities;
using OrderManagement.API.Repositories;
using Xunit;

namespace OrderManagement.Tests.UnitTests
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly IOrderService _orderService;

        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _orderService = new OrderService((API.Repositories.IOrderRepository)_orderRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateOrder_ShouldReturnNewOrder()
        {
            var order = new Order();
            _orderRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);

            var result = await _orderService.CreateOrderAsync();

            _orderRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Order>()), Times.Once);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddProductToOrder_ShouldAddProduct()
        {
            var order = new Order { Id = 1 };
            _orderRepositoryMock.Setup(repo => repo.GetByIdAsync(order.Id)).ReturnsAsync(order);

            var product = new Product(1, "Test Product", 10m);
            await _orderService.AddProductToOrderAsync(order.Id, product);

            _orderRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Order>(o => o.Products.Contains(product))), Times.Once);
        }

        [Fact]
        public async Task CloseOrder_ShouldCloseOrder()
        {
            var order = new Order { Id = 1 };
            order.AddProduct(new Product(1, "Test Product", 10m));
            _orderRepositoryMock.Setup(repo => repo.GetByIdAsync(order.Id)).ReturnsAsync(order);

            await _orderService.CloseOrderAsync(order.Id);

            _orderRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Order>(o => o.IsClosed)), Times.Once);
            Assert.True(order.IsClosed);
        }

        [Fact]
        public async Task GetAllOrders_WithIsClosedParameter_ShouldReturnFilteredOrders()
        {
            var openOrder = new Order();
            var closedOrder = new Order();
            closedOrder.CloseOrder();

            var orders = new List<Order> { openOrder, closedOrder };

            _orderRepositoryMock.Setup(repo => repo.GetAllAsync(null)).ReturnsAsync(orders);
            _orderRepositoryMock.Setup(repo => repo.GetAllAsync(true)).ReturnsAsync(orders.Where(o => o.IsClosed));
            _orderRepositoryMock.Setup(repo => repo.GetAllAsync(false)).ReturnsAsync(orders.Where(o => !o.IsClosed));

            var allOrders = await _orderService.GetAllOrdersAsync();
            var closedOrders = await _orderService.GetAllOrdersAsync(true);
            var openOrders = await _orderService.GetAllOrdersAsync(false);

            Assert.Equal(2, allOrders.Count());
            Assert.Single(closedOrders);
            Assert.Single(openOrders);
        }
    }
}
