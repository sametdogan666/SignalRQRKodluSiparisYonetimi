using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
{
    public EfMenuTableDal(SignalRContext context) : base(context)
    {
    }

    public int GetMenuTableCount()
    {
        using var context = new SignalRContext();

        return context.MenuTables.Count();
    }
}