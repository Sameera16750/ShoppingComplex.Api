using AutoMapper;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Core.Entities;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

namespace ShoppingComplex.Application.Services.Implementations
{
    public class StoreCategoryServiceImpl : IStoreCategoryService
    {
        // auto mapper instance
        private readonly IMapper _mapper;

        // store category repository instance
        private IStoreCategoryRepo _storeCategoryRepo;

        public StoreCategoryServiceImpl(IStoreCategoryRepo storeCategoryRepo, IMapper mapper)
        {
            _storeCategoryRepo = storeCategoryRepo;
            _mapper = mapper;
        }

        // for save store category
        public HttpResponse SaveStoreCategory(StoreCategoryRequest storeCategoryRequest)
        {
            try
            {
                if (_storeCategoryRepo.SaveStoreCategory(_mapper.Map<StoreCatogory>(storeCategoryRequest)) > 0)
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

        // for update existing Store Category
        public HttpResponse UpdateStoreCategory(int id, StoreCategoryRequest storeCategoryRequest)
        {
            try
            {
                StoreCatogory storeCategory = _mapper.Map<StoreCatogory>(storeCategoryRequest);
                storeCategory.Id = id;
                if (_storeCategoryRepo.UpdateStoreCategory(storeCategory) > 0)
                {
                    return new HttpResponse(200, "Store Category Update Success");
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

        // for get Store Category by id
        public HttpResponse GetStoreCategoryById(int id)
        {
            try
            {
                StoreCatogory? storeCategory = _storeCategoryRepo.GetStoreCategoryById(id);
                if (storeCategory != null)
                {
                    return new HttpResponse(200, _mapper.Map<StoreCategoryResponse>(storeCategory));
                }

                return new HttpResponse(200, "Data not fond from this id");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get Store Category list by status
        public HttpResponse GetStoreCategoryListByStatus(int status)
        {
            try
            {
                List<StoreCatogory> storeCategories = _storeCategoryRepo.GetAllByStatus(status);
                if (storeCategories.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<StoreCategoryResponse>>(storeCategories));
                }

                return new HttpResponse(200, "Data not fond from this status");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for get all Store Category list
        public HttpResponse GetAll()
        {
            try
            {
                List<StoreCatogory> storeCategories = _storeCategoryRepo.GetAll();
                if (storeCategories.Count > 0)
                {
                    return new HttpResponse(200, _mapper.Map<List<StoreCategoryResponse>>(storeCategories));
                }

                return new HttpResponse(404, "This Table is Empty");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }
        }

        // for delete Store Category
        public HttpResponse DeleteStoreCategory(int id)
        {
            try
            {
                if (_storeCategoryRepo.GetStoreCategoryById(id)!=null)
                {
                    if (_storeCategoryRepo.DeleteFloor(id)>0)
                    {
                        return new HttpResponse(200, "Store Category Delete Succeeded");
                    }

                    return new HttpResponse(500, "Internal server Error");
                }

                return new HttpResponse(404, $"this element (Store Category id : {id}) not found in DB");
            }
            catch (Exception e)
            {
                return new HttpResponse(500, e.Message);
            }

        }
    }
}