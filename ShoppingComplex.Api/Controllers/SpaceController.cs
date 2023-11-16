using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Services.Interfaces;
using HttpResponse = ShoppingComplex.Application.Models.Response.HttpResponse;

namespace ShoppingComplex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceController : ControllerBase
    {
        // space interface instance
        private readonly ISpaceService _spaceService;

        // constructor
        public SpaceController(ISpaceService spaceService)
        {
            _spaceService = spaceService;
        }

        // for add new space to DB
        [HttpPost("add")]
        public HttpResponse SaveSpace([FromBody] SpaceRequest spaceRequest)
        {
            return _spaceService.SaveSpace(spaceRequest);
        }

        // for update space
        [HttpPut("update/{id}")]
        public HttpResponse UpdateSpace(int id,[FromBody] SpaceRequest spaceRequest)
        {
            return _spaceService.UpdateSpace(id,spaceRequest);
        }
        
        // for get space by Id
        [HttpGet("get_by_id/{id}")]
        public HttpResponse GetFloor(int id)
        {
            return _spaceService.GetFloorById(id);
        }

        
        // for get Space list by status 
        [HttpGet("get_by_status/{status}")]
        public HttpResponse GetFloorListByStatus(int status)
        {
            return _spaceService.GetSpaceListByStatus(status);
        }
        
        // for get all Spaces list
        [HttpGet("get_all")]
        public HttpResponse GetFloorListByStatus()
        {
            return _spaceService.GetAll();
        }
        
    }
}