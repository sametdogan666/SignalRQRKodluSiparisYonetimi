using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class MoneyCaseManager : IMoneyCaseService
{
    private readonly IMoneyCaseDal _moneyCaseDal;

    public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
    {
        _moneyCaseDal = moneyCaseDal;
    }

    public void Add(MoneyCase entity)
    {
        _moneyCaseDal.Add(entity);
    }

    public void Remove(MoneyCase entity)
    {
        _moneyCaseDal.Remove(entity);
    }

    public void Update(MoneyCase entity)
    {
        _moneyCaseDal.Update(entity);
    }

    public MoneyCase? GetById(int id)
    {
        return _moneyCaseDal.GetById(id);
    }

    public List<MoneyCase> GetAll()
    {
        return _moneyCaseDal.GetAll();
    }

    public decimal GetTotalMoneyCaseAmount()
    {
        return _moneyCaseDal.GetTotalMoneyCaseAmount();
    }
}