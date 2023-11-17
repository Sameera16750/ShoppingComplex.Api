using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Services.Interfaces;
using HttpResponse = ShoppingComplex.Application.Models.Response.HttpResponse;

namespace ShoppingComplex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        // store service instance
        private readonly IStoreService _storeService;
        
        // constructor
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        // add new store 
        [HttpPost("add")]
        public HttpResponse SaveStore([FromBody] StoreRequest storeRequest)
        {
            return _storeService.SaveStore(storeRequest);
        }
        
        // for update store 
        [HttpPut("update/{id}")]
        public HttpResponse UpdateStore(int id, [FromBody] StoreRequest storeRequest)
        {
            return _storeService.UpdateStore(id,storeRequest);
        }
        
        // for get store by Id
        [HttpGet("get_by_id/{id}")]
        public HttpResponse GetStore(int id)
        {
            return _storeService.GetStoreById(id);
        }
        
        // for get store list by status 
        [HttpGet("get_by_status/{status}")]
        public HttpResponse GetStoreListByStatus(int status)
        {
            return _storeService.GetStoreListByStatus(status);
        }
        
        // for get store list by status 
        [HttpGet("get_all")]
        public HttpResponse GetStoreListByStatus()
        {
            return _storeService.GetAll();
        }
        
        // for delete store 
        [HttpDelete("delete/{id}")]
        public HttpResponse DeleteStoreCategory(int id)
        {
            return _storeService.DeleteStore(id);
        }

    }
}
