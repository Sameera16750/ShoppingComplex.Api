using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Services.Interfaces;
using HttpResponse = ShoppingComplex.Application.Models.Response.HttpResponse;

namespace ShoppingComplex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        // contractor service instance
        private readonly IContractorService _contractorService;
        
        // constructor
        public ContractorController(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }
        
        // add new Contractor 
        [HttpPost("add")]
        public HttpResponse SaveContractor([FromBody] ContractorRequest contractorRequest)
        {
            return _contractorService.SaveContractor(contractorRequest);
        }
        
        // for update Contractor 
        [HttpPut("update/{id}")]
        public HttpResponse UpdateContractor(int id, [FromBody] ContractorRequest contractorRequest)
        {
            return _contractorService.UpdateContractor(id,contractorRequest);
        }
        
        // for get Contractor by Id
        [HttpGet("get_by_id/{id}")]
        public HttpResponse GetContractor(int id)
        {
            return _contractorService.GetContractorById(id);
        }
        
        // for get Contractor list by status 
        [HttpGet("get_by_status/{status}")]
        public HttpResponse GetContractorListByStatus(int status)
        {
            return _contractorService.GetContractorListByStatus(status);
        }
        
        // for get Contractor list by status 
        [HttpGet("get_all")]
        public HttpResponse GetContractorListByStatus()
        {
            return _contractorService.GetAll();
        }
        
        // for delete Contractor 
        [HttpDelete("delete/{id}")]
        public HttpResponse DeleteContractorCategory(int id)
        {
            return _contractorService.DeleteContractor(id);
        }
    }
}
