using Microsoft.EntityFrameworkCore;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.DBContext;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Infrastructure.Repositories.Implementations
{
    public class FloorRepoImpl : IFloorRepo
    {
        // for application DB instance
        private readonly ApplicationDbContext _applicationDbContext;

        // constructor
        public FloorRepoImpl(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // for save floor in db        
        public int SaveFloor(Floor floor)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[InsertFloor] '{floor.FloorNumber}',{floor.TotalSpaces},{floor.Status}");
        }

        // for update existing floor in db
        public int UpdateFloor(Floor floor)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[UpdateFloor] {floor.Id},{floor.FloorNumber},{floor.TotalSpaces},{floor.Status}");
        }

        // for get floor details from db using id
        public Floor? GetFloorById(int id)
        {
            return _applicationDbContext.Floors.FromSqlRaw($"EXEC [dbo].[SelectFloorById] {id}").ToList().FirstOrDefault();
        }

        // for get all floor details from db using status or without status
        public List<Floor> GetAllByStatus(int status)
        {
            return _applicationDbContext.Floors.FromSqlRaw($"EXEC [dbo].[SelectFloorsByStatus] {status}").ToList();
        }

        // for get all floor list from DB 
        public List<Floor> GetAll()
        {
            return _applicationDbContext.Floors.FromSqlRaw($"EXEC [dbo].[SelectFloorsByStatus]").ToList();
        }

        // for delete floor
        public int DeleteFloor(int id)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw($"EXEC [dbo].[DeleteFloor] {id}");
        }
    }
}