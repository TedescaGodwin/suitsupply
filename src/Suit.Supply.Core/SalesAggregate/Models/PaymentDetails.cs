using Ardalis.GuardClauses;
using Suit.Supply.SharedKernel;
using Suit.Supply.SharedKernel.Interfaces;

namespace Suit.Supply.Core.SalesAggregate.Models
{
    public class PaymentDetails : EntityBase, IAggregateRoot 
    {
        public bool IsPaid { get; set; }
    }
    
}

