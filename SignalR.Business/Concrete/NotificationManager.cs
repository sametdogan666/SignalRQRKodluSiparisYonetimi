using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class NotificationManager : INotificationService
{
    private readonly INotificationDal _notificationDal;

    public NotificationManager(INotificationDal notificationDal)
    {
        _notificationDal = notificationDal;
    }

    public void Add(Notification entity)
    {
        _notificationDal.Add(entity);
    }

    public void Remove(Notification entity)
    {
        _notificationDal.Remove(entity);
    }

    public void Update(Notification entity)
    {
        _notificationDal.Update(entity);
    }

    public Notification? GetById(int id)
    {
        return _notificationDal.GetById(id);
    }

    public List<Notification> GetAll()
    {
        return _notificationDal.GetAll();
    }

    public int GetNotificationCountByStatusFalse()
    {
        return _notificationDal.GetNotificationCountByStatusFalse();
    }

    public List<Notification> GetAllNotificationByFalse()
    {
        return _notificationDal.GetAllNotificationByFalse();
    }

    public void NotificationChangeToStatusTrue(int id)
    {
        _notificationDal.NotificationChangeToStatusTrue(id);
    }

    public void NotificationChangeToStatusFalse(int id)
    {
        _notificationDal.NotificationChangeToStatusFalse(id);
    }
}