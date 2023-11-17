using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface IStoreService
    {
        // for save store
        HttpResponse SaveStore(StoreRequest storeRequest);

        // for update existing Store
        HttpResponse UpdateStore(int id,StoreRequest storeRequest);
        
        // for get Store by id
        HttpResponse GetStoreById(int id);
        
        // for get Store list by status
        HttpResponse GetStoreListByStatus(int status);
        
        // for get all Store list
        HttpResponse GetAll();

        // for delete Store
        HttpResponse DeleteStore(int id);
    }    
}

