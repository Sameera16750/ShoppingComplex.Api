using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface IContractorRepo
    {
        // for save Contractor in db        
        int SaveContractor(Contractor contractor);
        
        // for update Contractor  in db
        int UpdateContractor(Contractor contractor);

        // for get Contractor details from db using id
        Contractor? GetContractorById(int id);
        
        // for get all Contractor details from db using status
        List<Contractor> GetAllByStatus(int status);
        
        // for get all Contractor details from db
        List<Contractor> GetAll();
        
        // for delete Contractor 
        int Delete(int id);
    }
}