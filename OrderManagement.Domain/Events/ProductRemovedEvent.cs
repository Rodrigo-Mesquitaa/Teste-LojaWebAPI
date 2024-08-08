using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Events
{
    public class ProductRemovedEvent : IDomainEvent
    {
        public Order Order { get; }
        public Product Product { get; }

        public ProductRemovedEvent(Order order, Product product)
        {
            Order = order;
            Product = product;
        }
    }
}