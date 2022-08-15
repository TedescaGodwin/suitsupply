using Suit.Supply.Core.Interfaces;
using Suit.Supply.Core.SalesAggregate.Events;
using Suit.Supply.Core.SalesAggregate.Handlers;
using Moq;
using Xunit;
using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.Core.SalesAggregate;

namespace Suit.Supply.UnitTests.Core.Handlers
{
    public class OrderItemCompletedEmailNotificationHandlerHandle
    {
        private OrderItemCompletedEmailNotificationHandler _handler;
        private Mock<IEmailSender> _emailSenderMock;

        public OrderItemCompletedEmailNotificationHandlerHandle()
        {
            _emailSenderMock = new Mock<IEmailSender>();
            _handler = new OrderItemCompletedEmailNotificationHandler(_emailSenderMock.Object);
        }

        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {
#nullable disable
            Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
#nullable enable
        }

        [Fact]
        public async Task SendsEmailGivenEventInstance()
        {
            await _handler.Handle(new SalesCompletedEvent(new SalesDetail()), CancellationToken.None);

            _emailSenderMock.Verify(sender => sender.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }

}

