using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class DiscountManager : IDiscountService
{
    private readonly IDiscountDal _discountDal;

    public DiscountManager(IDiscountDal discountDal)
    {
        _discountDal = discountDal;
    }

    public void Add(Discount entity)
    {
        _discountDal.Add(entity);
    }

    public void Remove(Discount entity)
    {
       _discountDal.Remove(entity);
    }

    public void Update(Discount entity)
    {
        _discountDal.Update(entity);
    }

    public Discount? GetById(int id)
    {
        return _discountDal.GetById(id);
    }

    public List<Discount> GetAll()
    {
        return _discountDal.GetAll();
    }
}