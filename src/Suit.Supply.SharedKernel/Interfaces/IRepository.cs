using Ardalis.Specification;

namespace Suit.Supply.SharedKernel.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {

    }
}


