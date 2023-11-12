using AutoMapper;
using SignalR.Dto.AboutDto;
using SignalR.Dto.BasketDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class BasketMappingProfile : Profile
{
    public BasketMappingProfile()
    {
        CreateMap<Basket, CreateBasketDto>().ReverseMap();
        CreateMap<Basket, ResultBasketWithProductDto>().ReverseMap();
    }
}