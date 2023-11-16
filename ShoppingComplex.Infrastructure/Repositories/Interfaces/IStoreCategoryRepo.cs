using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface IStoreCategoryRepo
    {
        // for save Store Category in db        
        int SaveStoreCategory(StoreCatogory storeCategory);
        
        // for update Store Category in db
        int UpdateStoreCategory(StoreCatogory storeCategory);

        // for get Store Category details from db using id
        StoreCatogory? GetStoreCategoryById(int id);
        
        // for get all Store Category details from db using status
        List<StoreCatogory> GetAllByStatus(int status);
        
        // for get all Store Category details from db
        List<StoreCatogory> GetAll();
        
        // for delete Store Category
        int DeleteFloor(int id);
    }    
}

