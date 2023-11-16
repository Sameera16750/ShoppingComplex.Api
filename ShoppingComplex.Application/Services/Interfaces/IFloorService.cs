using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface IFloorService
    {
        // for save floor
        HttpResponse SaveFloor(FloorRequest floorRequest);
        // for update existing floor
        HttpResponse UpdateFloor(int id,FloorRequest floorRequest);
        
        // for get floor by id
        HttpResponse GetFloorById(int id);
        
        // for get floor list by status
        HttpResponse GetFloorListByStatus(int status);
        
        // for get all floor list
        HttpResponse GetAll();
    }    
}

