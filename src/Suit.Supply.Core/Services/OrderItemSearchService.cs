using Ardalis.Result;
using Suit.Supply.Core.Interfaces;
using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.SharedKernel.Interfaces;
using Suit.Supply.Core.SalesAggregate.Specifications;

namespace Suit.Supply.Core.Services
{
    public class OrderItemSearchService : IOrderItemSearchService
    {
        private readonly IRepository<SalesDetail> _repository;

        public OrderItemSearchService(IRepository<SalesDetail> repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<SalesDetail>>> GetAllSalesAsync()
        {
            var salesSpec = new SalesWithOrderItemsSpec();

            var sales = await _repository.ListAsync(salesSpec);

            if (sales == null)
            {
                return Result<List<SalesDetail>>.NotFound();
            }

            var incompleteSpec = new IncompleteOrderItemsSearchSpec();
            try
            {
                var items = incompleteSpec.Evaluate(sales).ToList();

                return new Result<List<SalesDetail>>(items);
            }
            catch (Exception ex)
            {
                return Result<List<SalesDetail>>.Error(new[] { ex.Message });
            }
        }

        public async Task<Result<SalesDetail>> GetNextIncompleteOrderItemAsync(int salesId)
        {
            var salesSpec = new SalesByIdWithOrderItemsSpec(salesId);
            var sales = await _repository.ListAsync(salesSpec);
            if (sales == null)
            {
                return Result<SalesDetail>.NotFound();
            }

            var incompleteSpec = new IncompleteOrderItemsSpec();
            var items = incompleteSpec.Evaluate(sales).ToList();
            if (!items.Any())
            {
                return Result<SalesDetail>.NotFound();
            }

            return new Result<SalesDetail>(items.First());
        }
    }
}
