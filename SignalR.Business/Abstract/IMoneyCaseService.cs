using SignalR.Entities.Entities;

namespace SignalR.Business.Abstract;

public interface IMoneyCaseService : IGenericService<MoneyCase>
{
    decimal GetTotalMoneyCaseAmount();
}