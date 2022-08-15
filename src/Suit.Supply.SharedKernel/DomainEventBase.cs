using MediatR;

namespace Suit.Supply.SharedKernel
{
    public abstract class DomainEventBase : INotification
    {
      public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}


