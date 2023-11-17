using Microsoft.EntityFrameworkCore;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.DBContext;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Infrastructure.Repositories.Implementations
{
    public class StoreRepoServiceImpl : IStoreRepo
    {
        // DB context instance
        private readonly ApplicationDbContext _applicationDbContext;

        // repository instance
        private readonly IStoreOwnerRepo _storeOwnerRepo;
        private readonly ISpaceRepo _spaceRepo;
        private readonly IStoreCategoryRepo _categoryRepo;

        // constructor
        public StoreRepoServiceImpl(ApplicationDbContext applicationDbContext, IStoreOwnerRepo storeOwnerRepo,
            ISpaceRepo spaceRepo, IStoreCategoryRepo categoryRepo)
        {
            _applicationDbContext = applicationDbContext;
            _storeOwnerRepo = storeOwnerRepo;
            _spaceRepo = spaceRepo;
            _categoryRepo = categoryRepo;
        }

        // for save Store in db        
        public int SaveStore(Store store)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $" EXEC [dbo].[InsertStore] '{store.StoreName}',{store.StoreOwner},{store.StoreCategory},{store.Space}," +
                $"{store.MonthlyCharge},{store.KeyMoney},'{store.RentalDate}','{store.RentalEndDate}',{store.Status}");
        }

        // for update Store  in db
        public int UpdateStore(Store store)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[UpdateStore] {store.Id},'{store.StoreName}',{store.StoreOwner},{store.StoreCategory},{store.Space}," +
                $"{store.MonthlyCharge},{store.KeyMoney},'{store.RentalDate}','{store.RentalEndDate}',{store.Status}");
        }

        // for get Store details from db using id
        public Store? GetStoreById(int id)
        {
            return UpdateStoreList(_applicationDbContext.Stores.FromSqlRaw($"EXEC [dbo].[SelectStoreById] {id}")
                    .ToList())
                .FirstOrDefault();
        }

        // for get all Store details from db using status
        public List<Store> GetAllByStatus(int status)
        {
            return UpdateStoreList(_applicationDbContext.Stores.FromSqlRaw($"EXEC [dbo].[SelectStoreByStatus] {status}")
                .ToList());
        }

        // for get all Store details from db
        public List<Store> GetAll()
        {
            return UpdateStoreList(
                _applicationDbContext.Stores.FromSqlRaw($"EXEC [dbo].[SelectStoreByStatus]").ToList());
        }

        // for delete Store 
        public int Delete(int id)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw($"EXEC [dbo].[DeleteStore] {id}");
        }

        //remove unwanted objects
        private List<Store> UpdateStoreList(List<Store> stores)
        {
            List<Store> updatedStores = new List<Store>();
            foreach (var store in stores)
            {
                store.SpaceNavigation = _spaceRepo.GetSpaceById(store.Space) ?? store.SpaceNavigation;
                store.StoreOwnerNavigation =
                    _storeOwnerRepo.GetStoreOwnerById(store.StoreOwner) ?? store.StoreOwnerNavigation;
                store.StoreCategoryNavigation = _categoryRepo.GetStoreCategoryById(store.StoreCategory) ??
                                                store.StoreCategoryNavigation;
                updatedStores.Add(store);
            }

            return updatedStores;
        }
    }
}