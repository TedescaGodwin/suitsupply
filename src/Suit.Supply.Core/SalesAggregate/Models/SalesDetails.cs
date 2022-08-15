using Ardalis.GuardClauses;
using Suit.Supply.Core.SalesAggregate.Enums;
using Suit.Supply.Core.SalesAggregate.Events;
using Suit.Supply.SharedKernel;
using Suit.Supply.SharedKernel.Interfaces;


namespace Suit.Supply.Core.SalesAggregate.Models
{
    public class SalesDetail : EntityBase, IAggregateRoot
    {
        private List<OrderItem> _items = new();

        public IEnumerable<OrderItem> OrderItems => _items.AsReadOnly(); 
        public OrderStatus OrderStatus { get; private set; } = OrderStatus.Created;

        public bool IsPaid { get; private set; }

        public AlterationStatus AlterationStatus { get; private set; } = AlterationStatus.Pending;

        public SalesDetail MarkOrderAsPaid()
        {
            if (!IsPaid)
            {
                IsPaid = true;
                OrderStatus = OrderStatus.OrderPaid;
                AlterationStatus = AlterationStatus.Started;
                RegisterDomainEvent(new SalesOrderPaidEvent(this));
            }

            return this;
        }

        public SalesDetail MarkOrderAsCompleted()
        {
            if (AlterationStatus.Equals(AlterationStatus.Started))
            {
                OrderStatus = OrderStatus.Done;
                AlterationStatus = AlterationStatus.Finished;
                RegisterDomainEvent(new SalesCompletedEvent(this));
                //AlterationFinished
            }

            return this;
        }

        public void AddOrderItem(OrderItem newSalesOrderItem)
        {
            Guard.Against.Null(newSalesOrderItem, nameof(newSalesOrderItem));
            _items.Add(newSalesOrderItem);

            var newItemAddedEvent = new NewSalesOrderAddedEvent(this);
            base.RegisterDomainEvent(newItemAddedEvent);
        }

        public override string ToString()
        {
            string status = nameof(OrderStatus);
            return $"{Id}: Status: {status}";
        }

    }
    
}

