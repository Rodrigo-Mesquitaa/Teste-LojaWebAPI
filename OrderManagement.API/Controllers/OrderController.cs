using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            var order = await _orderService.CreateOrderAsync();
            return Ok(order);
        }

        [HttpPost("{orderId}/add-product")]
        public async Task<IActionResult> AddProductToOrder(int orderId, [FromBody] Product product)
        {
            await _orderService.AddProductToOrderAsync(orderId, product);
            return Ok();
        }

        [HttpDelete("{orderId}/remove-product/{productId}")]
        public async Task<IActionResult> RemoveProductFromOrder(int orderId, int productId)
        {
            await _orderService.RemoveProductFromOrderAsync(orderId, productId);
            return Ok();
        }

        [HttpPost("{orderId}/close")]
        public async Task<IActionResult> CloseOrder(int orderId)
        {
            await _orderService.CloseOrderAsync(orderId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] bool? isClosed = null)
        {
            var orders = await _orderService.GetAllOrdersAsync(isClosed);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
