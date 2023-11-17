using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface IStoreOwnerService
    {
        // for save store owner
        HttpResponse SaveStoreOwner(StoreOwnerRequest storeOwnerRequest);

        // for update existing Store Owner
        HttpResponse UpdateStoreOwner(int id,StoreOwnerRequest storeOwnerRequest);
        
        // for get Store Owner by id
        HttpResponse GetStoreOwnerById(int id);
        
        // for get Store Owner list by status
        HttpResponse GetStoreOwnerListByStatus(int status);
        
        // for get all Store Owner list
        HttpResponse GetAll();

        // for delete Store Owner
        HttpResponse DeleteStoreOwner(int id);
    
    }
}
