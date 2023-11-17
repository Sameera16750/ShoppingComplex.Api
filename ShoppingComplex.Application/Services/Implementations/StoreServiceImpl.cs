using AutoMapper;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Application.Services.Implementations
{
    public class StoreServiceImpl : IStoreService
    {
        // auto mapper instance
        private readonly IMapper _mapper;

        // store repository instance
        private readonly IStoreRepo _storeRepo;
        private readonly IStoreCategoryRepo _categoryRepo;
        private readonly IStoreOwnerRepo _storeOwnerRepo;
        private readonly ISpaceRepo _spaceRepo;

        public StoreServiceImpl(IMapper mapper, IStoreRepo storeRepo, IStoreCategoryRepo categoryRepo,
            IStoreOwnerRepo storeOwnerRepo, ISpaceRepo spaceRepo)
        {
            _mapper = mapper;
            _storeRepo = storeRepo;
            _categoryRepo = categoryRepo;
            _storeOwnerRepo = storeOwnerRepo;
            _spaceRepo = spaceRepo;
        }

        // for save store
        public HttpResponse SaveStore(StoreRequest storeRequest)
        {
            try
            {
                Space? space = _spaceRepo.GetSpaceById(storeRequest.Space);
                if (_storeOwnerRepo.GetStoreOwnerById(storeRequest.StoreOwner) != null &&
                    _categoryRepo.GetStoreCategoryById(storeRequest.StoreCategory) != null &&
                    space!= null)
                {
                    //changing space is filled status
                    space.Status = 2;
                    if (_spaceRepo.UpdateSpace(space)>0)
                    {
                        if (_storeRepo.SaveStore(_mapper.Map<Store>(storeRequest)) > 0)
                        {
                            return new HttpResponse(200, "data adding succeeded");
                        }
                    }
                   
                    return new HttpResponse(500, "internal server Error, Please try again later");
                }

                return new HttpResponse(404,
                    $"store category (id:{storeRequest.StoreCategory}) or store owner (id : {storeRequest.StoreOwner}) or space (id :{storeRequest.Space}) not found ");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for update existing Store
        public HttpResponse UpdateStore(int id, StoreRequest storeRequest)
        {
            try
            {
                Space? space = _spaceRepo.GetSpaceById(storeRequest.Space);
                if (_storeOwnerRepo.GetStoreOwnerById(storeRequest.StoreOwner) != null &&
                    _categoryRepo.GetStoreCategoryById(storeRequest.StoreCategory) != null &&
                    space!= null)
                {
                    Store? getStore = _storeRepo.GetStoreById(id);
                    Store store = _mapper.Map<Store>(storeRequest);
                    store.Id = id;
                    
                    if (getStore!=null && getStore.Space!=storeRequest.Space)
                    {
                        space.Status = 1;
                        _spaceRepo.UpdateSpace(space);
                    }

                    if (_storeRepo.UpdateStore(store) > 0)
                    {
                        return new HttpResponse(200, "Store Data Update Success");
                    }

                    return new HttpResponse(500, "internal server Error, Please try again later");
                }

                return new HttpResponse(404,
                    $"store category (id:{storeRequest.StoreCategory}) or store owner (id : {storeRequest.StoreOwner}) not found");
            }
            catch (Exception)
            {
                return new HttpResponse(500, "internal server Error, Please try again later");
            }
        }

        // for get Store by id
        public HttpResponse GetStoreById(int id)
        {
            try
            {
                Store? store = _storeRepo.GetStoreById(id);
                if (store != null)
                {
                    return new HttpResponse(200, _mapper.Map<StoreResponse>(store));
                }

                return new HttpResponse(200, "Data not fond from this id");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get Store list by status
        public HttpResponse GetStoreListByStatus(int status)
        {
            try
            {
                List<Store> stores = _storeRepo.GetAllByStatus(status);
                if (stores.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<StoreResponse>>(stores));
                }

                return new HttpResponse(200, "Data not fond from this status");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get all Store list
        public HttpResponse GetAll()
        {
            try
            {
                List<Store> stores = _storeRepo.GetAll();
                if (stores.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<StoreResponse>>(stores));
                }

                return new HttpResponse(404, "This Table is Empty");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for delete Store
        public HttpResponse DeleteStore(int id)
        {
            try
            {
                if (_storeRepo.GetStoreById(id) != null)
                {
                    if (_storeRepo.Delete(id) > 0)
                    {
                        return new HttpResponse(200, "Store Delete Succeeded");
                    }

                    return new HttpResponse(500, "Internal server Error");
                }

                return new HttpResponse(404, $"this element (Store id : {id}) not found in DB");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }
    }
}