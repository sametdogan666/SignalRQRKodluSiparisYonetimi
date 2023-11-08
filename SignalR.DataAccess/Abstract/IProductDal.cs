using SignalR.Dto.ProductDto;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Abstract;

public interface IProductDal : IGenericDal<Product>
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