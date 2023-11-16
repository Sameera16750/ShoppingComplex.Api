using AutoMapper;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Application.Services.Implementations
{
    public class FloorServiceImpl : IFloorService
    {
        // for repository instance
        private readonly IFloorRepo _floorRepo;

        // for Automapper instance
        private readonly IMapper _mapper;

        // constructor
        public FloorServiceImpl(IFloorRepo floorRepo, IMapper mapper)
        {
            _floorRepo = floorRepo;
            _mapper = mapper;
        }

        // for save floor
        public HttpResponse SaveFloor(FloorRequest floorRequest)
        {
            try
            {
                if (_floorRepo.SaveFloor(_mapper.Map<Floor>(floorRequest)) > 0)
                {
                    return new HttpResponse(200, "data adding succeeded");
                }
                else
                {
                    return new HttpResponse(500, "internal server Error, Please try again later");
                }
            }
            catch (Exception)
            {
                return new HttpResponse(500, "internal server Error");
            }
        }

        // for update existing floor
        public HttpResponse UpdateFloor(int id, FloorRequest floorRequest)
        {
            try
            {
                Floor floor = _mapper.Map<Floor>(floorRequest);
                floor.Id = id;
                if (_floorRepo.UpdateFloor(floor) > 0)
                {
                    return new HttpResponse(200, "Floor Update Success");
                }
                else
                {
                    return new HttpResponse(500, "internal server Error, Please try again later");
                }
            }
            catch (Exception)
            {
                return new HttpResponse(500, "internal server Error, Please try again later");
            }
        }

        // for update get floor by id
        public HttpResponse GetFloorById(int id)
        {
            try
            {
                Floor? floor = _floorRepo.GetFloorById(id);
                if (_floorRepo.GetFloorById(id) != null)
                {
                    return new HttpResponse(200, _mapper.Map<FloorResponse>(floor));
                }

                return new HttpResponse(200, "Data not fond from this id");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get floor list by status
        public HttpResponse GetFloorListByStatus(int status)
        {
            try
            {
                List<Floor> floorList = _floorRepo.GetAllByStatus(status);
                if (floorList.Count>0)
                {
                    return new HttpResponse(200, _mapper.Map<List<FloorResponse>>(floorList));
                }

                return new HttpResponse(200, "Data not fond from this id");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get all floor list
        public HttpResponse GetAll()
        {try
            {
                List<Floor> floorList = _floorRepo.GetAll();
                if (floorList.Count>0)
                {
                    return new HttpResponse(200, _mapper.Map<List<FloorResponse>>(floorList));
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