using AutoMapper;
using SignalR.Dto.DiscountDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class DiscountMappingProfile : Profile
{
    public DiscountMappingProfile()
    {
        CreateMap<Discount, CreateDiscountDto>().ReverseMap();
        CreateMap<Discount, GetDiscountDto>().ReverseMap();
        CreateMap<Discount, ResultDiscountDto>().ReverseMap();
        CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
    }
}