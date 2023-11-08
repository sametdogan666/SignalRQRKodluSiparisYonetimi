using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class OrderDetailManager : IOrderDetailService
{
    private readonly IOrderDetailDal _orderDetailDal;

    public OrderDetailManager(IOrderDetailDal orderDetailDal)
    {
        _orderDetailDal = orderDetailDal;
    }

    public void Add(OrderDetail entity)
    {
        _orderDetailDal.Add(entity);
    }

    public void Remove(OrderDetail entity)
    {
       _orderDetailDal.Remove(entity);
    }

    public void Update(OrderDetail entity)
    {
       _orderDetailDal.Update(entity);
    }

    public OrderDetail? GetById(int id)
    {
        return _orderDetailDal.GetById(id);
    }

    public List<OrderDetail> GetAll()
    {
        return _orderDetailDal.GetAll();
    }
}