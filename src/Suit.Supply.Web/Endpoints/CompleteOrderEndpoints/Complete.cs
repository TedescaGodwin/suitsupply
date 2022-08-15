using Ardalis.ApiEndpoints;
using Suit.Supply.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.Infrastructure.Services;
using Suit.Supply.Infrastructure;
using Suit.Supply.Core.SalesAggregate.Enums;
using Suit.Supply.Web.Endpoints.SalesEndpoints;

namespace Suit.Supply.Web.Endpoints.CompleteOrderEndpoints
{
    public class Complete : EndpointBaseAsync
    .WithRequest<UpdateSalesRequest>
    .WithActionResult<UpdateSalesResponse>
    {
        private readonly IRepository<SalesDetail> _repository;
        private readonly IMyServiceBusClient _serviceBusClient;
        public Complete(IRepository<SalesDetail> repository, IMyServiceBusClient client)
        {
            _repository = repository;
            _serviceBusClient = client;
        }

        [HttpPut(UpdateSalesRequest.Route)]
        [SwaggerOperation(
            Summary = "Complete Order",
            Description = "Complete sales order alteration",
            OperationId = "Complete.Order",
            Tags = new[] { "CompleteOrderEndpoints" })
        ]
        public override async Task<ActionResult<UpdateSalesResponse>> HandleAsync(
          UpdateSalesRequest request,
            CancellationToken cancellationToken = new())
        {
            if (request.SalesId == 0)
            {
                return BadRequest();
            }

            var existingSales = await _repository.GetByIdAsync(request.SalesId, cancellationToken);

            if (existingSales == null)
            {
                return NotFound("Sales does not found");
            }

            AzureBusService service = new(_serviceBusClient);

            if (request.IsCompleted.Equals(true)
                && existingSales.AlterationStatus.Equals(AlterationStatus.Started))
            {
                existingSales.MarkOrderAsCompleted();
                await service.SendMessageAsync(existingSales, "alteration-order-finished");
                //send email
            }

            else return NotFound();

            await _repository.UpdateAsync(existingSales, cancellationToken);

            var response = new UpdateSalesResponse(
                sales: new SalesRecord());


            return Ok(response);
        }
    }
}


