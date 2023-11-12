using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
{
    public EfNotificationDal(SignalRContext context) : base(context)
    {
    }

    public int GetNotificationCountByStatusFalse()
    {
        using var context = new SignalRContext();
        
        return context.Notifications.Where(x => x.Status == false).Count();
    }

    public List<Notification> GetAllNotificationByFalse()
    {
        using var context = new SignalRContext();

        return context.Notifications.Where(x => x.Status == false).ToList();
    }
}