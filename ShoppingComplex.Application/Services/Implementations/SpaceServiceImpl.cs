using AutoMapper;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Application.Services.Implementations
{
    public class SpaceServiceImpl : ISpaceService
    {
        // auto mapper instance
        private readonly IMapper _mapper;

        // space repo instance
        private readonly ISpaceRepo _spaceRepo;

        // floor repository instance
        private readonly IFloorRepo _floorRepo;

        // constructor
        public SpaceServiceImpl(ISpaceRepo spaceRepo, IFloorRepo floorRepo, IMapper mapper)
        {
            _mapper = mapper;
            _spaceRepo = spaceRepo;
            _floorRepo = floorRepo;
        }

        // save new space
        public HttpResponse SaveSpace(SpaceRequest spaceRequest)
        {
            try
            {
                Floor? floor = _floorRepo.GetFloorById(spaceRequest.Floor);
                if (floor != null)
                {
                    if (_spaceRepo.SaveSpace(_mapper.Map<Space>(spaceRequest)) > 0)
                    {
                        return new HttpResponse(200, "new space record adding succeeded");
                    }

                    return new HttpResponse(500, "internal server Error, Please try again later");
                }

                return new HttpResponse(404, "This Floor not found");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for update existing space details
        public HttpResponse UpdateSpace(int id, SpaceRequest spaceRequest)
        {
            try
            {
                Floor? floor = _floorRepo.GetFloorById(spaceRequest.Floor);
                if (floor != null)
                {
                    Space space = _mapper.Map<Space>(spaceRequest);
                    space.Id = id;
                    if (_spaceRepo.UpdateSpace(space) > 0)
                    {
                        return new HttpResponse(200, "Space Update Success");
                    }

                    return new HttpResponse(500, "internal server Error, Please try again later");
                }

                return new HttpResponse(404, "This Floor not found");
            }
            catch (Exception)
            {
                return new HttpResponse(500, "internal server Error, Please try again later");
            }
        }

        // for get space by id
        public HttpResponse GetFloorById(int id)
        {
            try
            {
                Space? space = _spaceRepo.GetSpaceById(id);
                if (space != null)
                {
                    return new HttpResponse(200, _mapper.Map<SpaceResponse>(space));
                }

                return new HttpResponse(404, "Data not fond from this id");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }
        
        // for get Space list by status
        public HttpResponse GetSpaceListByStatus(int status)
        {
            try
            {
                List<Space> spaces = _spaceRepo.GetAllByStatus(status);
                if (spaces.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<SpaceResponse>>(spaces));
                }

                return new HttpResponse(200, "Data not fond from this status");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get all Space list
        public HttpResponse GetAll()
        {
            try
            {
                List<Space> spacesList = _spaceRepo.GetAll();
                if (spacesList.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<SpaceResponse>>(spacesList));
                }

                return new HttpResponse(200, "This Table is Empty");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }
    }
}