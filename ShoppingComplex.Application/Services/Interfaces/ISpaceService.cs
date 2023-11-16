using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface ISpaceService
    {
        // for add new space
        HttpResponse SaveSpace(SpaceRequest spaceRequest);
        
        // for update existing space details
        HttpResponse UpdateSpace(int id, SpaceRequest spaceRequest);

        // for get floor by id
        HttpResponse GetFloorById(int id);
        
        // for get Space list by status
        HttpResponse GetSpaceListByStatus(int status);
        
        // for get all Space list
        HttpResponse GetAll();
        
                
        // for update existing space details
        HttpResponse DeleteSpace(int id);

    }
}