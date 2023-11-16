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

        private IMapper _mapper;

        public MapperConfigs()
        {
            CreateMap<FloorRequest, Floor>();
            CreateMap<Floor,FloorResponse>();
        }

        public MapperConfigs(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<TDestination> MapList<TSource, TDestination>(List<TSource> sourceList)
        {
            return _mapper.Map<List<TDestination>>(sourceList);
        }
    }
    
}
