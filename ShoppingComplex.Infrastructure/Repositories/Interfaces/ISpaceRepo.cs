using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface ISpaceRepo
    {
        // for save space in db        
        int SaveSpace(Space space);
        
        // for update existing space in db
        int UpdateSpace(Space space);

        // for get space details from db using id
        Space? GetSpaceById(int id);
        
        // for get all space details from db using status
        List<Space> GetAllByStatus(int status);
        
        // for get all space details from db
        List<Space> GetAll();
    }
}