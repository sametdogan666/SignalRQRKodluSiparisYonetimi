using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Abstract;

public interface IDiscountDal : IGenericDal<Discount>
{
    void ChangeStatusToTrue(int id);
    void ChangeStatusToFalse(int id);
    List<Discount> GetListByStatusTrue();
}