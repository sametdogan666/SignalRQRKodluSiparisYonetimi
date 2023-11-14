using AutoMapper;
using SignalR.Dto.SliderDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class SliderMappingProfile : Profile
{
    public SliderMappingProfile()
    {
        CreateMap<Slider, CreateSliderDto>().ReverseMap();
        CreateMap<Slider, GetSliderDto>().ReverseMap();
        CreateMap<Slider, ResultSliderDto>().ReverseMap();
        CreateMap<Slider, UpdateSliderDto>().ReverseMap();
    }
}