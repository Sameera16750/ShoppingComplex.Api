using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Services.Interfaces;
using HttpResponse = ShoppingComplex.Application.Models.Response.HttpResponse;

namespace ShoppingComplex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        // for instance of floor service
        private readonly IFloorService _floorService;
        
        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }
        
        // for save floor 
        [HttpPost("add")]
        public HttpResponse SaveFloor([FromBody] FloorRequest floorRequest)
        {
            return _floorService.SaveFloor(floorRequest);
        }

        // for update floor
        [HttpPut("update/{id}")]
        public HttpResponse UpdateFloor(int id, [FromBody] FloorRequest floorRequest)
        {
            return _floorService.UpdateFloor(id, floorRequest);
        }
        
        // for get floor by Id
        [HttpGet("get_by_id/{id}")]
        public HttpResponse GetFloor(int id)
        {
            return _floorService.GetFloorById(id);
        }
        
        // for get floor list by status 
        [HttpGet("get_by_status/{status}")]
        public HttpResponse GetFloorListByStatus(int status)
        {
            return _floorService.GetFloorListByStatus(status);
        }
        
        // for get floor list by status 
        [HttpGet("get_all")]
        public HttpResponse GetFloorListByStatus()
        {
            return _floorService.GetAll();
        }
    }
}
