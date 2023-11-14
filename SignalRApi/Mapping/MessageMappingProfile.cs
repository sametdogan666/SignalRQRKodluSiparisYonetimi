using AutoMapper;
using SignalR.Dto.MessageDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class MessageMappingProfile : Profile
{
    public MessageMappingProfile()
    {
        CreateMap<Message, CreateMessageDto>().ReverseMap();
        CreateMap<Message, ResultMessageDto>().ReverseMap();
        CreateMap<Message, GetMessageDto>().ReverseMap();
        CreateMap<Message, UpdateMessageDto>().ReverseMap();
    }
}