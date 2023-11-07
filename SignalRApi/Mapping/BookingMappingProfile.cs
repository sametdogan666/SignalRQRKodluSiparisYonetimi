using AutoMapper;
using SignalR.Dto.BookingDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class BookingMappingProfile : Profile
{
    public BookingMappingProfile()
    {
        CreateMap<Booking, CreateBookingDto>().ReverseMap();
        CreateMap<Booking, GetBookingDto>().ReverseMap();
        CreateMap<Booking, ResultBookingDto>().ReverseMap();
        CreateMap<Booking, UpdateBookingDto>().ReverseMap();
    }
}