using Microsoft.EntityFrameworkCore;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.DBContext;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Infrastructure.Repositories.Implementations
{
    public class StoreOwnerRepoImpl : IStoreOwnerRepo
    {
        // DB context instance
        private ApplicationDbContext _applicationDbContext;

        public StoreOwnerRepoImpl(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // for save Store Owner in db        
        public int SaveStoreOwner(StoreOwner storeOwner)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[InsertStoreOwner] '{storeOwner.FirstName}','{storeOwner.LastName}','{storeOwner.Address}'" +
                $",'{storeOwner.ContactNo}','{storeOwner.Email}','{storeOwner.Nic}',{storeOwner.Status}");
        }

        // for update Store Owner in db
        public int UpdateStoreOwner(StoreOwner storeOwner)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[UpdateStoreOwner] {storeOwner.Id},'{storeOwner.FirstName}','{storeOwner.LastName}'," +
                $"'{storeOwner.Address}','{storeOwner.ContactNo}','{storeOwner.Email}','{storeOwner.Nic}',{storeOwner.Status}");
        }

        // for get Store Owner details from db using id
        public StoreOwner? GetStoreOwnerById(int id)
        {
            return _applicationDbContext.StoreOwners.FromSqlRaw($"EXEC [dbo].[SelectStoreOwnerById] {id}")
                .ToList()
                .FirstOrDefault();
        }

        // for get all Store Owner details from db using status
        public List<StoreOwner> GetAllByStatus(int status)
        {
            return _applicationDbContext.StoreOwners
                .FromSqlRaw($"EXEC [dbo].[SelectStoreOwnerByStatus] {status}").ToList();
        }

        // for get all Store Owner details from db
        public List<StoreOwner> GetAll()
        {
            return _applicationDbContext.StoreOwners
                .FromSqlRaw($"EXEC [dbo].[SelectStoreOwnerByStatus]").ToList();

        }

        // for delete Store Owner
        public int DeleteOwner(int id)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw($"EXEC [dbo].[DeleteStoreOwner] {id}");
        }
    }
}