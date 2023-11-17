using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface IMaintenanceRepo
    {
        // for save Maintenance in db        
        int SaveMaintenance(Maintenance maintenance);
        
        // for update existing Maintenance in db
        int UpdateMaintenance(Maintenance maintenance);

        // for get Maintenance details from db using id
        Maintenance? GetMaintenanceById(int id);
        
        // for get all Maintenance details from db using status 
        List<Maintenance> GetAllByStatus(int status);
        
        // for get all Maintenance details from db
        List<Maintenance> GetAll();
        
        // for delete Maintenance
        int DeleteMaintenance(int id);
    }
}