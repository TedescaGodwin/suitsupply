using Ardalis.ApiEndpoints;
using Suit.Supply.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.Infrastructure.Services;
using Suit.Supply.Infrastructure;
using Suit.Supply.Core.SalesAggregate.Enums;
using Suit.Supply.Web.Endpoints.SalesEndpoints;

namespace Suit.Supply.Web.Endpoints.PaymentEndpoints
{
    public class Payment : EndpointBaseAsync
    .WithRequest<UpdatePaymentRequest>
    .WithActionResult<UpdatePaymentResponse>
    {
        private readonly IRepository<SalesDetail> _repository;
        private readonly IMyServiceBusClient _serviceBusClient;
        public Payment(IRepository<SalesDetail> repository, IMyServiceBusClient client)
        {
            _repository = repository;
            _serviceBusClient = client;
        }

        [HttpPut(UpdatePaymentRequest.Route)]
        [SwaggerOperation(
            Summary = "Make a payment",
            Description = "Make a payment and publish event",
            OperationId = "Payment.Update",
            Tags = new[] { "PaymentEndpoints" })
        ]
        public override async Task<ActionResult<UpdatePaymentResponse>> HandleAsync(
          UpdatePaymentRequest request,
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

            if (request.IsPaid.Equals(true)
                && existingSales.AlterationStatus.Equals(AlterationStatus.Pending))
            {
                existingSales.MarkOrderAsPaid();
                await service.SendMessageAsync(existingSales, "sales-order-paid");
            }

            else return NotFound();

            await _repository.UpdateAsync(existingSales, cancellationToken);

            var response = new UpdatePaymentResponse(
                sales: new SalesRecord());

            return Ok(response);
        }
    }
}


