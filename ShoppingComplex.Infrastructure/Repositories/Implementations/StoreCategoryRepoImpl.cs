using Microsoft.EntityFrameworkCore;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.DBContext;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Infrastructure.Repositories.Implementations
{
    public class StoreCategoryRepoImpl : IStoreCategoryRepo
    {
        // DB context instance
        private readonly ApplicationDbContext _applicationDbContext;

        // constructor
        public StoreCategoryRepoImpl(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // for save Store Category in db        
        public int SaveStoreCategory(StoreCatogory storeCategory)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[InsertStoreCategory] '{storeCategory.CategoryName}',{storeCategory.Status}");
        }

        // for update Store Category floor in db
        public int UpdateStoreCategory(StoreCatogory storeCategory)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[UpdateStoreCategory] {storeCategory.Id},'{storeCategory.CategoryName}',{storeCategory.Status}");
        }

        // for get Store Category details from db using id
        public StoreCatogory? GetStoreCategoryById(int id)
        {
            return _applicationDbContext.StoreCatogories.FromSqlRaw($"EXEC [dbo].[SelectStoreCategoryById] {id}")
                .ToList()
                .FirstOrDefault();
        }

        // for get all Store Category details from db using status
        public List<StoreCatogory> GetAllByStatus(int status)
        {
            return _applicationDbContext.StoreCatogories
                .FromSqlRaw($"EXEC [dbo].[SelectStoreCategoryByStatus] {status}").ToList();
        }

        // for get all Store Category details from db
        public List<StoreCatogory> GetAll()
        {
            return _applicationDbContext.StoreCatogories
                .FromSqlRaw($"EXEC [dbo].[SelectStoreCategoryByStatus]").ToList();

        }

        // for delete Store Category
        public int DeleteStoreCategory(int id)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw($"EXEC [dbo].[DeleteStoreCategory] {id}");
        }
    }
}