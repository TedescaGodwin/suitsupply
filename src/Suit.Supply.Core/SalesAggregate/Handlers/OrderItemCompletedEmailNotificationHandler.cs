using Ardalis.GuardClauses;
using MediatR;
using Suit.Supply.Core.Interfaces;
using Suit.Supply.Core.SalesAggregate.Events;

namespace Suit.Supply.Core.SalesAggregate.Handlers
{
    public class OrderItemCompletedEmailNotificationHandler : INotificationHandler<SalesCompletedEvent>
    {
        private readonly IEmailSender _emailSender;

        public OrderItemCompletedEmailNotificationHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task Handle(SalesCompletedEvent domainEvent, CancellationToken cancellationToken)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            return _emailSender.SendEmailAsync("tedesca-test@suitsupply.com",
                                               "demo-test@suitsupply.com", 
                                               $"{domainEvent.CompletedSale.Id} is {nameof(domainEvent.CompletedSale.OrderStatus)}.",
                                               domainEvent.CompletedSale.ToString());
        }
    }
}
