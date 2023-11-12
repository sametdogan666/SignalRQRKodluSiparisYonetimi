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

    public void NotificationChangeToStatusTrue(int id)
    {
        using var context = new SignalRContext();

        var value = context.Notifications.Find(id);
        value.Status = true;
        //context.Notifications.Update(value);
        context.SaveChanges();
    }

    public void NotificationChangeToStatusFalse(int id)
    {
        using var context = new SignalRContext();

        var value = context.Notifications.Find(id);
        value.Status = false;
        //context.Notifications.Update(value);
        context.SaveChanges();
    }
}