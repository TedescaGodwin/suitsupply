using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suit.Supply.Core.Interfaces;
using Suit.Supply.Web.ApiModels;

namespace Suit.Supply.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : BaseApiController
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender; 
        }

        [HttpPost]
        public async Task<IActionResult> Email([FromBody] EmailDTO request)
        {
            await _emailSender.SendEmailAsync(request.To, request.From, "Order Completed", request.Body);
            return Ok(request);
         }
    }
}
