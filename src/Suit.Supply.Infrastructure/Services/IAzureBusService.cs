using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Infrastructure.Services
{
    public interface IAzureBusService
    {
        Task SendMessageAsync(SalesDetail detail, string topic);
        Task ReceiveMessageAsync (string topic);

    }
}