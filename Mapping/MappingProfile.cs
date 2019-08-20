using AutoMapper;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakesResources>();
            CreateMap<Model, ModelResorces>();
            CreateMap<Feature, FeatureResources>();
        }
    }
}