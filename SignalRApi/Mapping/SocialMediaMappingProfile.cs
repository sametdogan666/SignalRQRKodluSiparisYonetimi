using AutoMapper;
using SignalR.Dto.SocialMediaDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class SocialMediaMappingProfile : Profile
{
    public SocialMediaMappingProfile()
    {
        CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
        CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
        CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
        CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
    }
}