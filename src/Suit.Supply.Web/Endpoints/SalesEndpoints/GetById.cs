using Ardalis.ApiEndpoints;
using Suit.Supply.Core.SalesAggregate.Specifications;
using Suit.Supply.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Suit.Supply.Core.SalesAggregate.Models;

namespace Suit.Supply.Web.Endpoints.SalesEndpoints{
  public class GetById : EndpointBaseAsync
  .WithRequest<GetSalesByIdRequest>
  .WithActionResult<GetSalesByIdResponse>
{
  private readonly IRepository<SalesDetail> _repository;

  public GetById(IRepository<SalesDetail> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetSalesByIdRequest.Route)]
  [SwaggerOperation(
    Summary = "Gets a single Sales",
    Description = "Gets a single Sales by Id",
    OperationId = "Sales.GetById",
    Tags = new[] { "SalesEndpoints" })
  ]
  public override async Task<ActionResult<GetSalesByIdResponse>> HandleAsync(
    [FromRoute] GetSalesByIdRequest request,
    CancellationToken cancellationToken = new())
  {
    var spec = new SalesByIdWithOrderItemsSpec(request.SalesId);
    var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }

    var response = new GetSalesByIdResponse
    (
      id: entity.Id
    );

    return Ok(response);
  }
}
}

