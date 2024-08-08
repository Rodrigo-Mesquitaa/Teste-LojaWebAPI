using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Events
{
    public class OrderClosedEvent : IDomainEvent
    {
        public Order Order { get; }

        public OrderClosedEvent(Order order)
        {
            Order = order;
        }
    }
}