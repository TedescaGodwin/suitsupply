using Ardalis.Specification.EntityFrameworkCore;
using Suit.Supply.Infrastructure.Services;
using Suit.Supply.SharedKernel.Interfaces;

namespace Suit.Supply.Infrastructure.Data
{
    public class EntityFrameworkRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EntityFrameworkRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }


 
}

