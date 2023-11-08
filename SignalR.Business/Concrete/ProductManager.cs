using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Dto.ProductDto;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public void Add(Product entity)
    {
        _productDal.Add(entity);
    }

    public void Remove(Product entity)
    {
        _productDal.Remove(entity);
    }

    public void Update(Product entity)
    {
        _productDal.Update(entity);
    }

    public Product? GetById(int id)
    {
        return _productDal.GetById(id);
    }

    public List<Product> GetAll()
    {
        return _productDal.GetAll();
    }

    public List<ResultProductWithCategoryDto> GetProductsWithCategory()
    {
        return _productDal.GetProductsWithCategory();
    }

    public int GetProductCount()
    {
        return _productDal.GetProductCount();
    }

    public int GetProductCountByCategoryNameHamburger()
    {
        return _productDal.GetProductCountByCategoryNameHamburger();
    }

    public int GetProductCountByCategoryNameDrink()
    {
        return _productDal.GetProductCountByCategoryNameDrink();
    }

    public decimal GetProductPriceAvg()
    {
        return _productDal.GetProductPriceAvg();
    }

    public string GetProductNameByMaxPrice()
    {
        return _productDal.GetProductNameByMaxPrice();
    }

    public string GetProductNameByMinPrice()
    {
        return _productDal.GetProductNameByMinPrice();
    }
}