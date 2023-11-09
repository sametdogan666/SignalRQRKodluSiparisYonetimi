using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Abstract;

public interface IOrderDal : IGenericDal<Order>
{
    int GetTotalOrderCount();
    int GetActiveOrderCount();
    decimal GetLastOrderPrice();
    decimal GeTodayTotalPrice();

}