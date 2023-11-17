using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface IStoreOwnerRepo
    {
        // for save Store Owner in db        
        int SaveStoreOwner(StoreOwner storeOwner);
        
        // for update Store Owner in db
        int UpdateStoreOwner(StoreOwner storeOwner);

        // for get Store Owner details from db using id
        StoreOwner? GetStoreOwnerById(int id);
        
        // for get all Store Owner details from db using status
        List<StoreOwner> GetAllByStatus(int status);
        
        // for get all Store Owner details from db
        List<StoreOwner> GetAll();
        
        // for delete Store Owner
        int DeleteOwner(int id);
    }
}
