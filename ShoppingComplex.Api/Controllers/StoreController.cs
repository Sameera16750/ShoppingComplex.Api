using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Models.Request;
using HttpResponse = ShoppingComplex.Application.Models.Response.HttpResponse;

namespace ShoppingComplex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        // constructor
        public StoreController(){}

        [HttpPost("add")]
        public HttpResponse SaveStore([FromBody]StoreRequest storeRequest)
        {
            return null;
        }
    }
}
