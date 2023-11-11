using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfBasketDal : GenericRepository<Basket>, IBasketDal
{
    public EfBasketDal(SignalRContext context) : base(context)
    {
    }

    public List<Basket> GetBasketByMenuTableNumber(int id)
    {
        using var context = new SignalRContext() ;

        var results = context.Baskets.Where(x => x.MenuTableId == id).ToList();

        return results;
    }
}