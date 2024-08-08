using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Events
{
    public class ProductAddedEvent : IDomainEvent
    {
        public Order Order { get; }
        public Product Product { get; }

        public ProductAddedEvent(Order order, Product product)
        {
            Order = order;
            Product = product;
        }
    }
}