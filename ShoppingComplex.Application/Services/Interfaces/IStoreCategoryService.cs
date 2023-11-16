using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface IStoreCategoryService
    {
        // for save store category
        HttpResponse SaveStoreCategory(StoreCategoryRequest storeCategoryRequest);

        // for update existing Store Category
        HttpResponse UpdateStoreCategory(int id,StoreCategoryRequest storeCategoryRequest);
        
        // for get Store Category by id
        HttpResponse GetStoreCategoryById(int id);
        
        // for get Store Category list by status
        HttpResponse GetStoreCategoryListByStatus(int status);
        
        // for get all Store Category list
        HttpResponse GetAll();

        // for delete Store Category
        HttpResponse DeleteStoreCategory(int id);
    }    
}

