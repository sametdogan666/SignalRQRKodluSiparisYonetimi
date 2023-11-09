using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Abstract;

public interface IMoneyCaseDal : IGenericDal<MoneyCase>
{
    decimal GetTotalMoneyCaseAmount();
}