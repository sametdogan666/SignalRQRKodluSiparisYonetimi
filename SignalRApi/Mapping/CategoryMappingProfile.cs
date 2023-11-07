using AutoMapper;
using SignalR.Dto.CategoryDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, GetCategoryDto>().ReverseMap();
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
    }
}