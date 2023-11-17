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
        private readonly IFloorRepo _floorRepo;

        // constructor 
        public SpaceRepoImpl(ApplicationDbContext applicationDbContext, IFloorRepo floorRepo)
        {
            _applicationDbContext = applicationDbContext;
            _floorRepo = floorRepo;
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
            return UpdateSpaceList(_applicationDbContext.Spaces.FromSqlRaw($"EXEC [dbo].[SelectSpaceById] {id}")
                .ToList()).FirstOrDefault();
        }

        // for get all space details from db using status
        public List<Space> GetAllByStatus(int status)
        {
            return UpdateSpaceList(_applicationDbContext.Spaces.FromSqlRaw($"EXEC [dbo].[SelectSpaceByStatus] {status}").ToList());
        }

        // for get all space details from db
        public List<Space> GetAll()
        {
            return UpdateSpaceList(_applicationDbContext.Spaces.FromSqlRaw($"EXEC [dbo].[SelectSpaceByStatus]").ToList());
        }

        // for delete space
        public int DeleteSpace(int id)
        {
            return _applicationDbContext.Database.ExecuteSqlRaw($"EXEC [dbo].[DeleteSpace] {id}");
        }

        //remove unwanted objects
        private List<Space> UpdateSpaceList(List<Space> spaces)
        {
            List<Space> updatedList = new List<Space>();

            if (spaces.Count > 0)
            {
                foreach (var space in spaces)
                {
                    Floor? floor = _floorRepo.GetFloorById(space.Floor);
                    if (floor != null)
                    {
                        space.FloorNavigation = floor;
                    }

                    updatedList.Add(space);
                }
            }

            return updatedList;
        }
    }
}