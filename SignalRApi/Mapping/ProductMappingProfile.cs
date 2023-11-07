using AutoMapper;
using SignalR.Dto.ProductDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Mapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, GetProductDto>().ReverseMap();
        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
    }
}