using Ardalis.Result;
using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Core.Interfaces;

public interface IOrderItemSearchService
{
    Task<Result<List<SalesDetail>>> GetAllSalesAsync();
    Task<Result<SalesDetail>> GetNextIncompleteOrderItemAsync(int saleId);
}
