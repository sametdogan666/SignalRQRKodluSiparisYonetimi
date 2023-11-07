using AutoMapper;
using SignalR.Dto.FeatureDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class FeatureMappingProfile : Profile
{
    public FeatureMappingProfile()
    {
        CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        CreateMap<Feature, GetFeatureDto>().ReverseMap();
        CreateMap<Feature, ResultFeatureDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
    }
}