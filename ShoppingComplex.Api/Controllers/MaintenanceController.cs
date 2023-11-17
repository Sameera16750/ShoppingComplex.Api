using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Services.Interfaces;
using HttpResponse = ShoppingComplex.Application.Models.Response.HttpResponse;

namespace ShoppingComplex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        // maintenance service instance
        private readonly IMaintenanceService _maintenanceService;
        
        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        // for save Maintenance 
        [HttpPost("add")]
        public HttpResponse SaveMaintenance([FromBody] MaintenanceRequest maintenanceRequest)
        {
            return _maintenanceService.SaveMaintenance(maintenanceRequest);
        }

        // for update Maintenance
        [HttpPut("update/{id}")]
        public HttpResponse UpdateMaintenance(int id, [FromBody] MaintenanceRequest maintenanceRequest)
        {
            return _maintenanceService.UpdateMaintenance(id, maintenanceRequest);
        }

        // for get Maintenance by Id
        [HttpGet("get_by_id/{id}")]
        public HttpResponse GetMaintenance(int id)
        {
            return _maintenanceService.GetMaintenanceById(id);
        }
        
        // for get Maintenance list by status 
        [HttpGet("get_by_status/{status}")]
        public HttpResponse GetMaintenanceListByStatus(int status)
        {
            return _maintenanceService.GetMaintenanceListByStatus(status);
        }
        
        // for get Maintenance list by status 
        [HttpGet("get_all")]
        public HttpResponse GetMaintenanceListByStatus()
        {
            return _maintenanceService.GetAll();
        }
        
        // for delete Maintenance
        [HttpDelete("delete/{id}")]
        public HttpResponse DeleteMaintenance(int id)
        {
            return _maintenanceService.DeleteMaintenance(id);
        }
        
    }
}
