using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;
using System.Linq;

namespace SignalR.DataAccess.EntityFramework;

public class EfOrderDal : GenericRepository<Order>, IOrderDal
{
    public EfOrderDal(SignalRContext context) : base(context)
    {
    }

    public int GetTotalOrderCount()
    {
        using var context = new SignalRContext();

        return context.Orders.Count();
    }

    public int GetActiveOrderCount()
    {
        using var context = new SignalRContext();

        return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
    }

    public decimal GetLastOrderPrice()
    {
        using var context = new SignalRContext();

        return context.Orders.OrderByDescending(x => x.Id).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
    }

    public decimal GeTodayTotalPrice()
    {
        using var context = new SignalRContext();

        return context.Orders.Where(x=>x.OrderDate == DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(y=>y.TotalPrice);
    }
}