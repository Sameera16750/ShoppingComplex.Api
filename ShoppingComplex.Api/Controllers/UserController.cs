using Microsoft.AspNetCore.Mvc;

namespace ShoppingComplex.Api.Controllers
{
    // this controller used for all tasks related to user class
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // this endpoint used for get user details
        [HttpGet(Name ="GetUser")]
        public string GetUser()
        {
            return "Sameera";
        }
    }
}
