using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface IFloorRepo
    {
        // for save floor in db        
        int SaveFloor(Floor floor);
        
        // for update existing floor in db
        int UpdateFloor(Floor floor);

        // for get floor details from db using id
        Floor? GetFloorById(int id);
        
        // for get all floor details from db using status or without status
        List<Floor> GetAllByStatus(int status);
        
        // for get all floor details from db
        List<Floor> GetAll();
        
        // for delete floor
        int DeleteFloor(int id);
    }    
}

