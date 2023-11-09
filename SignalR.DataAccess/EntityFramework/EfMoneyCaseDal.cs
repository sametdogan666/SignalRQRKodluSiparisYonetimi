using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
{
    public EfMoneyCaseDal(SignalRContext context) : base(context)
    {
    }

    public decimal GetTotalMoneyCaseAmount()
    {
        using var context = new SignalRContext();

        return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
    }
}