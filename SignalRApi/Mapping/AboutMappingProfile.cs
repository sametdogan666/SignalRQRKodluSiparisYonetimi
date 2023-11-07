using AutoMapper;
using SignalR.Dto.AboutDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class AboutMappingProfile : Profile
{
    public AboutMappingProfile()
    {
        CreateMap<About, CreateAboutDto>().ReverseMap();
        CreateMap<About, GetAboutDto>().ReverseMap();
        CreateMap<About, ResultAboutDto>().ReverseMap();
        CreateMap<About, UpdateAboutDto>().ReverseMap();
    }
}