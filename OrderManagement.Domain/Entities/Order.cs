using OrderManagement.Domain.Events;
using OrderManagement.Domain.Aggregates;

namespace OrderManagement.Domain.Entities
{
    public class Order : AggregateRoot
    {
        public int Id { get; set; }
        public List<Product> Products { get; private set; } = new List<Product>();
        public bool IsClosed { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public void AddProduct(Product product)
        {
            if (IsClosed) throw new InvalidOperationException("Cannot add product to a closed order.");
            Products.Add(product);
            AddDomainEvent(new ProductAddedEvent(this, product));
        }

        private void AddDomainEvent(ProductAddedEvent productAddedEvent)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Product product)
        {
            if (IsClosed) throw new InvalidOperationException("Cannot remove product from a closed order.");
            Products.Remove(product);
            AddDomainEvent(new ProductRemovedEvent(this, product));
        }

        private void AddDomainEvent(ProductRemovedEvent productRemovedEvent)
        {
            throw new NotImplementedException();
        }

        public void CloseOrder()
        {
            if (!Products.Any()) throw new InvalidOperationException("Cannot close an order without products.");
            IsClosed = true;
            AddDomainEvent(new OrderClosedEvent(this));
        }

        private void AddDomainEvent(OrderClosedEvent orderClosedEvent)
        {
            throw new NotImplementedException();
        }
    }
}
