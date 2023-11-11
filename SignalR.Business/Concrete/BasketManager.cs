using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Dto.BasketDto;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class BasketManager : IBasketService
{
    private readonly IBasketDal _basketDal;

    public BasketManager(IBasketDal basketDal)
    {
        _basketDal = basketDal;
    }

    public void Add(Basket entity)
    {
        _basketDal.Add(entity);
    }

    public void Remove(Basket entity)
    {
        _basketDal.Remove(entity);
    }

    public void Update(Basket entity)
    {
        _basketDal.Update(entity);
    }

    public Basket? GetById(int id)
    {
        return _basketDal.GetById(id);
    }

    public List<Basket> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<Basket> GetBasketByMenuTableNumber(int id)
    {
        return _basketDal.GetBasketByMenuTableNumber(id);
    }

    public List<ResultBasketWithProductDto> GetBasketListByMenuTableWithProductName(int id)
    {
        return _basketDal.GetBasketListByMenuTableWithProductName(id);
    }
}