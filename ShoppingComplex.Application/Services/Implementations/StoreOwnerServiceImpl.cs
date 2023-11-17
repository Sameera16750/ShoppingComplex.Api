using AutoMapper;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Application.Services.Implementations
{
    public class StoreOwnerServiceImpl : IStoreOwnerService
    {
        // auto mapper instance
        private readonly IMapper _mapper;

        // store owner repository instance
        private readonly IStoreOwnerRepo _storeOwnerRepo;
        
        // constructor
        public StoreOwnerServiceImpl(IMapper mapper, IStoreOwnerRepo storeOwnerRepo)
        {
            _mapper = mapper;
            _storeOwnerRepo = storeOwnerRepo;
        }

        // for save store owner
        public HttpResponse SaveStoreOwner(StoreOwnerRequest storeOwnerRequest)
        {
            try
            {
                if (_storeOwnerRepo.SaveStoreOwner(_mapper.Map<StoreOwner>(storeOwnerRequest)) > 0)
                {
                    return new HttpResponse(200, "data adding succeeded");
                }

                return new HttpResponse(500, "internal server Error, Please try again later");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, "internal server Error");
            }
        }

        // for update existing Store Owner
        public HttpResponse UpdateStoreOwner(int id, StoreOwnerRequest storeOwnerRequest)
        {
            try
            {
                StoreOwner storeOwner = _mapper.Map<StoreOwner>(storeOwnerRequest);
                storeOwner.Id = id;
                if (_storeOwnerRepo.UpdateStoreOwner(storeOwner) > 0)
                {
                    return new HttpResponse(200, "Store Owner Data Update Success");
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

        // for get Store Owner by id
        public HttpResponse GetStoreOwnerById(int id)
        {
            try
            {
                StoreOwner? storeOwner = _storeOwnerRepo.GetStoreOwnerById(id);
                if (storeOwner != null)
                {
                    return new HttpResponse(200, _mapper.Map<StoreOwnerResponse>(storeOwner));
                }

                return new HttpResponse(200, "Data not fond from this id");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get Store Owner list by status
        public HttpResponse GetStoreOwnerListByStatus(int status)
        {
            try
            {
                List<StoreOwner> storeOwners = _storeOwnerRepo.GetAllByStatus(status);
                if (storeOwners.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<StoreOwnerResponse>>(storeOwners));
                }

                return new HttpResponse(200, "Data not fond from this status");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get all Store Owner list
        public HttpResponse GetAll()
        {
            try
            {
                List<StoreOwner> storeOwners = _storeOwnerRepo.GetAll();
                if (storeOwners.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<StoreOwnerResponse>>(storeOwners));
                }

                return new HttpResponse(404, "This Table is Empty");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for delete Store Owner
        public HttpResponse DeleteStoreOwner(int id)
        {
            try
            {
                if (_storeOwnerRepo.GetStoreOwnerById(id) != null)
                {
                    if (_storeOwnerRepo.DeleteOwner(id) > 0)
                    {
                        return new HttpResponse(200, "Store Owner Delete Succeeded");
                    }

                    return new HttpResponse(500, "Internal server Error");
                }

                return new HttpResponse(404, $"this element (Store Owner id : {id}) not found in DB");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }
    }
}