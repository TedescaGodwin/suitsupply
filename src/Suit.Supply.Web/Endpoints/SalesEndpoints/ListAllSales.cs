using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Suit.Supply.Core.Services;
using Suit.Supply.Core.SalesAggregate.Enums;

namespace Suit.Supply.Web.Endpoints.SalesEndpoints
{

    public class ListAllSales : EndpointBaseAsync
  .WithRequest<ListRequest>
  .WithActionResult<ListResponse>
{
  private readonly OrderItemSearchService _searchService;

  public ListAllSales(OrderItemSearchService searchService)
  {
    _searchService = searchService;
  }

  [HttpGet("/Sales/AllSales")]
  [SwaggerOperation(
    Summary = "Gets a list of a sales's items",
    Description = "Gets a list of a sales's items",
    OperationId = "Sales.AllSales",
    Tags = new[] { "SalesEndpoints" })
  ]
  public override async Task<ActionResult<ListResponse>> HandleAsync(
    [FromQuery] ListRequest request,
    CancellationToken cancellationToken = new())
  {
    var response = new ListResponse(new List<SalesRecord>());
    var result = await _searchService.GetAllSalesAsync();

    if (result.Status == Ardalis.Result.ResultStatus.Ok)
    {
        response.SalesRecord = new List<SalesRecord>(
            (IEnumerable<SalesRecord>)result.Value.Where(
            item => item.AlterationStatus.Equals(AlterationStatus.Pending)).ToList());
    }
    else if (result.Status == Ardalis.Result.ResultStatus.Invalid)
    {
      return BadRequest(result.ValidationErrors);
    }
    else if (result.Status == Ardalis.Result.ResultStatus.NotFound)
    {
      return NotFound();
    }

    return Ok(response);
  }
}

}

