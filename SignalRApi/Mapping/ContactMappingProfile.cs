using AutoMapper;
using SignalR.Dto.ContactDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class ContactMappingProfile : Profile
{
    public ContactMappingProfile()
    {
        CreateMap<Contact, CreateContactDto>().ReverseMap();
        CreateMap<Contact, GetContactDto>().ReverseMap();
        CreateMap<Contact, ResultContactDto>().ReverseMap();
        CreateMap<Contact, UpdateContactDto>().ReverseMap();
    }
}