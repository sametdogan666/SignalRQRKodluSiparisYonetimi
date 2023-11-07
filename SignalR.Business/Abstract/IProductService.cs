using SignalR.Dto.ProductDto;
using SignalR.Entities.Entities;

namespace SignalR.Business.Abstract;

public interface IProductService : IGenericService<Product>
{
    List<ResultProductWithCategoryDto> GetProductsWithCategory();
}