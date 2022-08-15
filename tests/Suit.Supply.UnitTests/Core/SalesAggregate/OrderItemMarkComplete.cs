using Suit.Supply.Core.SalesAggregate.Events;
using Xunit;

namespace Suit.Supply.UnitTests.Core.SalesAggregate
{
    public class OrderItemMarkAsPaid
    {
        [Fact]
        public void SetsPaidToTrue()
        {
            var item = new SaleDetailBuilder()
                .WithDefaultValues()
                .Build();

            item.MarkOrderAsPaid();

            Assert.True(item.IsPaid);
        }

        [Fact]
        public void RaisesCompletedSalesEvent()
        {
            var item = new SaleDetailBuilder().Build();

            item.MarkOrderAsPaid().MarkOrderAsCompleted();

            Assert.Single(item.DomainEvents);
            Assert.IsType<SalesCompletedEvent>(item.DomainEvents.First());
        }
    }

}

