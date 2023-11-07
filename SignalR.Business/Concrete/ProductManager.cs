using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
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
}