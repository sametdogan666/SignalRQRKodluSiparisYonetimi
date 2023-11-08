using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;

    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }

    public void Add(Order entity)
    {
        _orderDal.Add(entity);
    }

    public void Remove(Order entity)
    {
       _orderDal.Remove(entity);
    }

    public void Update(Order entity)
    {
        _orderDal.Update(entity);
    }

    public Order? GetById(int id)
    {
        return _orderDal.GetById(id);
    }

    public List<Order> GetAll()
    {
        return _orderDal.GetAll();
    }

    public int GetTotalOrderCount()
    {
        return _orderDal.GetTotalOrderCount();
    }

    public int GetActiveOrderCount()
    {
        return _orderDal.GetActiveOrderCount();
    }

    public decimal GetLastOrderPrice()
    {
        return _orderDal.GetLastOrderPrice();
    }
}