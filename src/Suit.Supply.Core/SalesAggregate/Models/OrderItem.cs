using Ardalis.GuardClauses;
using Suit.Supply.SharedKernel;

namespace Suit.Supply.Core.SalesAggregate.Models
{
    public class OrderItem : EntityBase
    {
        public decimal SleeveRight { get; private set; }
        public decimal SleeveLeft { get; private set; }
        public decimal TrouserRight { get; private set; }
        public decimal TrouserLeft { get; private set; }

        public OrderItem UpdateOrder(decimal sleeveRight, decimal sleeveLeft, decimal trouserRight, decimal trouserLeft)
        {
            SleeveLeft = sleeveLeft;
            SleeveRight = sleeveRight; 
            TrouserLeft = trouserLeft;
            TrouserRight = trouserRight;

            return this;
        }

        
    
    }
}
