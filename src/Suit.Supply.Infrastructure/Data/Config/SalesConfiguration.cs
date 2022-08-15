using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Infrastructure.Data.Config
{
    public class SalesConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            
        }
    }
}


