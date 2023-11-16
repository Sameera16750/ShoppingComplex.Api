using Microsoft.EntityFrameworkCore;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.DBContext;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Infrastructure.Repositories.Implementations
{
    public class SpaceRepoImpl : ISpaceRepo
    {
        // for db context instance
        private readonly ApplicationDbContext _applicationDbContext;

        // constructor 
        public SpaceRepoImpl(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // for save space in db        
        public int SaveSpace(Space space)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[InsertSpace] {space.Floor},'{space.SpaceNumber}','{space.SpaceSize}',{space.Status}");
        }

        // for update existing space in db
        public int UpdateSpace(Space space)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw(
                $"EXEC [dbo].[UpdateSpace] {space.Id},{space.Floor},'{space.SpaceNumber}','{space.SpaceSize}',{space.Status}");
        }

        // for get space details from db using id
        public Space? GetSpaceById(int id)
        {
            return _applicationDbContext.Spaces.FromSqlRaw($"EXEC [dbo].[SelectSpaceById] {id}").ToList().FirstOrDefault();
        }

        // for get all space details from db using status
        public List<Space> GetAllByStatus(int status)
        {
            return _applicationDbContext.Spaces.FromSqlRaw($"EXEC [dbo].[SelectSpaceByStatus] {status}").ToList();
        }

        // for get all space details from db
        public List<Space> GetAll()
        {
            return _applicationDbContext.Spaces.FromSqlRaw($"EXEC [dbo].[SelectSpaceByStatus]").ToList();
        }
    }
}