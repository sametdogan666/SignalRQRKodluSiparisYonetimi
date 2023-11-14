using SignalR.Entities.Entities;

namespace SignalR.Business.Abstract;

public interface IDiscountService : IGenericService<Discount>
{
    void ChangeStatusToTrue(int id);
    void ChangeStatusToFalse(int id);
}