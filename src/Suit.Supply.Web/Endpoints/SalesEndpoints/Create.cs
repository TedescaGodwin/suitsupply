using Ardalis.ApiEndpoints;
using Suit.Supply.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.Web.ApiModels;

namespace Suit.Supply.Web.Endpoints.SalesEndpoints{
  public class Create : EndpointBaseAsync
  .WithRequest<CreateSalesRequest>
  .WithActionResult<CreateSalesResponse>
{
  private readonly IRepository<SalesDetail> _repository;

  public Create(IRepository<SalesDetail> repository)
  {
    _repository = repository;
  }

  [HttpPost("/Sales")]
  [SwaggerOperation(
    Summary = "Creates a new Sales",
    Description = "Creates a new Sales",
    OperationId = "Sales.Create",
    Tags = new[] { "SalesEndpoints" })
  ]
  public override async Task<ActionResult<CreateSalesResponse>> HandleAsync(
    CreateSalesRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request.SleeveRight != 0 
        || request.SleeveLeft != 0 
        || request.TrouserLeft != 0
        || request.TrouserRight != 0)
    {
      return BadRequest();
    }
            
    var newSales = new SalesDetail();
    var items = new OrderItem();
        items.UpdateOrder(request.SleeveRight, request.SleeveLeft, request.TrouserRight, request.TrouserRight);
        newSales.AddOrderItem(items);
    var createdItem = await _repository.AddAsync(newSales, cancellationToken);
        var response = new CreateSalesResponse
        (
            id: createdItem.Id,
            orderItems: OrderItemDTO.FromOrderItems(createdItem.OrderItems.ToList())
        );

    return Ok(response);
  }
}

}

