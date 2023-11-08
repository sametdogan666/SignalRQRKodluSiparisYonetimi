using SignalR.Dto.ProductDto;
using SignalR.Entities.Entities;

namespace SignalR.Business.Abstract;

public interface IProductService : IGenericService<Product>
{
    List<ResultProductWithCategoryDto> GetProductsWithCategory();
    int GetProductCount();
    int GetProductCountByCategoryNameHamburger();
    int GetProductCountByCategoryNameDrink();
    decimal GetProductPriceAvg();
    string GetProductNameByMaxPrice();
    string GetProductNameByMinPrice();
    decimal GetProductPriceByHamburgerAvg();
}