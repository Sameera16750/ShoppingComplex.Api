using AutoMapper;
using ShoppingComplex.Application.Models.Request;
using ShoppingComplex.Application.Models.Response;
using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Application.Helpers
{
    // this class used for add auto mapper for mapping DTO to Another DTO 
    public class MapperConfigs : Profile
    {
        // this used for add mapping configs 
        public MapperConfigs()
        {
            CreateMap<FloorRequest, Floor>();
            CreateMap<Floor, FloorResponse>();
            CreateMap<SpaceRequest, Space>();
            CreateMap<Space, SpaceResponse>();
            CreateMap<StoreCategoryRequest, StoreCatogory>();
            CreateMap<StoreCatogory,StoreCategoryResponse>();
            CreateMap<StoreOwnerRequest, StoreOwner>();
            CreateMap<StoreOwner, StoreOwnerResponse>();
            CreateMap<StoreRequest, Store>();
            CreateMap<Store, StoreResponse>();
            CreateMap<ContractorRequest, Contractor>();
            CreateMap<Contractor,ContractorResponse>();
            CreateMap<MaintenanceRequest,Maintenance>();
            CreateMap<Maintenance,MaintenanceResponse>();
        }
    }
}