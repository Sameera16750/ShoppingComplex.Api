using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface IContractorService
    {
        // for save Contractor
        HttpResponse SaveContractor(ContractorRequest contractorRequest);

        // for update existing Contractor
        HttpResponse UpdateContractor(int id,ContractorRequest contractorRequest);
        
        // for get Contractor by id
        HttpResponse GetContractorById(int id);
        
        // for get Contractor list by status
        HttpResponse GetContractorListByStatus(int status);
        
        // for get all Contractor list
        HttpResponse GetAll();

        // for delete Contractor
        HttpResponse DeleteContractor(int id);
    }
}