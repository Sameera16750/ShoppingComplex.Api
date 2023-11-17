using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface IStoreRepo
    {
        // for save Store in db        
        int SaveStore(Store store);
        
        // for update Store  in db
        int UpdateStore(Store store);

        // for get Store details from db using id
        Store? GetStoreById(int id);
        
        // for get all Store details from db using status
        List<Store> GetAllByStatus(int status);
        
        // for get all Store details from db
        List<Store> GetAll();
        
        // for delete Store 
        int Delete(int id);
    }   
}