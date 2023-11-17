using Microsoft.EntityFrameworkCore;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.DBContext;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Infrastructure.Repositories.Implementations
{
    public class ContractorRepoImpl : IContractorRepo
    {
        // DB context instance
        private ApplicationDbContext _applicationDbContext;

        // constructor
        public ContractorRepoImpl(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // for save Contractor in db        
        public int SaveContractor(Contractor contractor)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[InsertContractor] '{contractor.Name}','{contractor.ContactNo}','{contractor.Email}','" +
                $"{contractor.Address}',{contractor.Status}");
        }

        // for update Contractor  in db
        public int UpdateContractor(Contractor contractor)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[UpdateContractor] {contractor.Id},'{contractor.Name}','{contractor.ContactNo}','{contractor.Email}','" +
                $"{contractor.Address}',{contractor.Status}");
        }

        // for get Contractor details from db using id
        public Contractor? GetContractorById(int id)
        {
            return _applicationDbContext.Contractors.FromSqlRaw($"EXEC [dbo].[SelectContractorById] {id}").ToList().FirstOrDefault();
        }

        // for get all Contractor details from db using status
        public List<Contractor> GetAllByStatus(int status)
        {
            return _applicationDbContext.Contractors.FromSqlRaw($"EXEC [dbo].[SelectContractorByStatus] {status}").ToList();
        }

        // for get all Contractor details from db
        public List<Contractor> GetAll()
        {
            return _applicationDbContext.Contractors.FromSqlRaw($"EXEC [dbo].[SelectContractorByStatus]").ToList();
        }

        // for delete Contractor 
        public int Delete(int id)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw($"EXEC [dbo].[DeleteContractor] {id}");
        }
    }
}