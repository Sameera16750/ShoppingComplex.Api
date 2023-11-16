using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Services.Interfaces;
using HttpResponse = ShoppingComplex.Application.Models.Response.HttpResponse;

namespace ShoppingComplex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreCategoryController : ControllerBase
    {
        // store category instance
        private readonly IStoreCategoryService _storeCategoryService;
        
        public StoreCategoryController(IStoreCategoryService storeCategoryService)
        {
            _storeCategoryService = storeCategoryService;
        }

        // add new store category
        [HttpPost("add")]
        public HttpResponse SaveStoreCategory([FromBody] StoreCategoryRequest storeCategoryRequest)
        {
            return _storeCategoryService.SaveStoreCategory(storeCategoryRequest);
        }
        
        // for update store category
        [HttpPut("update/{id}")]
        public HttpResponse UpdateStoreCategory(int id, [FromBody] StoreCategoryRequest storeCategoryRequest)
        {
            return _storeCategoryService.UpdateStoreCategory(id, storeCategoryRequest);
        }
        
        // for get store category by Id
        [HttpGet("get_by_id/{id}")]
        public HttpResponse GetStoreCategory(int id)
        {
            return _storeCategoryService.GetStoreCategoryById(id);
        }
        
        // for get store category list by status 
        [HttpGet("get_by_status/{status}")]
        public HttpResponse GetStoreCategoryListByStatus(int status)
        {
            return _storeCategoryService.GetStoreCategoryListByStatus(status);
        }
        
        // for get store category list by status 
        [HttpGet("get_all")]
        public HttpResponse GetStoreCategoryListByStatus()
        {
            return _storeCategoryService.GetAll();
        }
        
        // for delete store category
        [HttpDelete("delete/{id}")]
        public HttpResponse DeleteStoreCategory(int id)
        {
            return _storeCategoryService.DeleteStoreCategory(id);
        }
    }
}
