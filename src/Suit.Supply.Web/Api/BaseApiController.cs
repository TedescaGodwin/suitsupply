using Microsoft.AspNetCore.Mvc;

namespace Suit.Supply.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
