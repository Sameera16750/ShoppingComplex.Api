using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface IMaintenanceService
    {
        // for save Maintenance
        HttpResponse SaveMaintenance(MaintenanceRequest maintenanceRequest);

        // for update existing Maintenance
        HttpResponse UpdateMaintenance(int id,MaintenanceRequest maintenanceRequest);
        
        // for get Maintenance by id
        HttpResponse GetMaintenanceById(int id);
        
        // for get Maintenance list by status
        HttpResponse GetMaintenanceListByStatus(int status);
        
        // for get all Maintenance list
        HttpResponse GetAll();

        // for delete Maintenance
        HttpResponse DeleteMaintenance(int id);
    }    
}

