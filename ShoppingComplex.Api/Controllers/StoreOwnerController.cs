using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Services.Interfaces;
using HttpResponse = ShoppingComplex.Application.Models.Response.HttpResponse;

namespace ShoppingComplex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreOwnerController : ControllerBase
    {
        private readonly IStoreOwnerService _storeOwnerService;
        
        //constructor
        public StoreOwnerController(IStoreOwnerService storeOwnerService)
        {
            _storeOwnerService = storeOwnerService;
        }
        
        // add new store owner
        [HttpPost("add")]
        public HttpResponse SaveStoreOwner([FromBody] StoreOwnerRequest storeOwnerRequest)
        {
            return _storeOwnerService.SaveStoreOwner(storeOwnerRequest);
        }
        
        // for update store owner
        [HttpPut("update/{id}")]
        public HttpResponse UpdateStoreOwner(int id, [FromBody] StoreOwnerRequest storeOwnerRequest)
        {
            return _storeOwnerService.UpdateStoreOwner(id,storeOwnerRequest);
        }
        
        // for get store owner by Id
        [HttpGet("get_by_id/{id}")]
        public HttpResponse GetStoreOwner(int id)
        {
            return _storeOwnerService.GetStoreOwnerById(id);
        }
        
        // for get store owner list by status 
        [HttpGet("get_by_status/{status}")]
        public HttpResponse GetStoreOwnerListByStatus(int status)
        {
            return _storeOwnerService.GetStoreOwnerListByStatus(status);
        }
        
        // for get store owner list by status 
        [HttpGet("get_all")]
        public HttpResponse GetStoreCategoryListByStatus()
        {
            return _storeOwnerService.GetAll();
        }
        
        // for delete store owner
        [HttpDelete("delete/{id}")]
        public HttpResponse DeleteStoreCategory(int id)
        {
            return _storeOwnerService.DeleteStoreOwner(id);
        }
        
    }
}
