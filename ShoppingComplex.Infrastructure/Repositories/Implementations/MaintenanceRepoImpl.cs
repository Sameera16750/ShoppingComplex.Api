using Microsoft.EntityFrameworkCore;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.DBContext;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Infrastructure.Repositories.Implementations
{
    public class MaintenanceRepoImpl : IMaintenanceRepo
    {
        // DB context instance
        private readonly ApplicationDbContext _applicationDbContext;

        //contractor repo instance
        private readonly IContractorRepo _contractor;

        // constructor
        public MaintenanceRepoImpl(ApplicationDbContext applicationDbContext, IContractorRepo contractor)
        {
            _applicationDbContext = applicationDbContext;
            _contractor = contractor;
        }

        // for save Maintenance in db        
        public int SaveMaintenance(Maintenance maintenance)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[InsertMaintenance] '{maintenance.MaintenanceType}','{maintenance.Location}'," +
                $"{maintenance.Contractor},'{maintenance.StartDate}','{maintenance.EndDate}',{maintenance.TotalCharge}," +
                $"{maintenance.AdvancedValue},{maintenance.Status}");
        }

        // for update existing Maintenance in db
        public int UpdateMaintenance(Maintenance maintenance)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[UpdateMaintenance] {maintenance.Id},'{maintenance.MaintenanceType}','{maintenance.Location}'," +
                $"{maintenance.Contractor},'{maintenance.StartDate}','{maintenance.EndDate}',{maintenance.TotalCharge}," +
                $"{maintenance.AdvancedValue},{maintenance.Status}");
        }

        // for get Maintenance details from db using id
        public Maintenance? GetMaintenanceById(int id)
        {
            return UpdateMaintenanceList(_applicationDbContext.Maintenances
                .FromSqlRaw($"EXEC [dbo].[SelectMaintenanceById] {id}")
                .ToList()).FirstOrDefault();
        }

        // for get all Maintenance details from db using status 
        public List<Maintenance> GetAllByStatus(int status)
        {
            return UpdateMaintenanceList(_applicationDbContext.Maintenances
                .FromSqlRaw($"EXEC [dbo].[SelectMaintenanceByStatus] {status}").ToList());
        }

        // for get all Maintenance details from db
        public List<Maintenance> GetAll()
        {
            return UpdateMaintenanceList(_applicationDbContext.Maintenances
                .FromSqlRaw($"EXEC [dbo].[SelectMaintenanceByStatus]").ToList());
        }

        // for delete Maintenance
        public int DeleteMaintenance(int id)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw($"EXEC [dbo].[DeleteMaintenance] {id}");
        }

        //remove unwanted objects
        private List<Maintenance> UpdateMaintenanceList(List<Maintenance> maintenances)
        {
            List<Maintenance> updatedList = new List<Maintenance>();

            if (maintenances.Count > 0)
            {
                foreach (var maintenance in maintenances)
                {
                    Contractor? contractor = _contractor.GetContractorById(maintenance.Contractor);
                    if (contractor != null)
                    {
                        maintenance.ContractorNavigation = contractor;
                    }

                    updatedList.Add(maintenance);
                }
            }

            return updatedList;
        }
    }
}