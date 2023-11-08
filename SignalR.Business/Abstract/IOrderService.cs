using SignalR.Entities.Entities;

namespace SignalR.Business.Abstract;

public interface IOrderService : IGenericService<Order>
{
    int GetTotalOrderCount();
    int GetActiveOrderCount();
    decimal GetLastOrderPrice();
}