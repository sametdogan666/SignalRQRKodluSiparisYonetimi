using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Abstract;

public interface INotificationDal : IGenericDal<Notification>
{
    int GetNotificationCountByStatusFalse();
    List<Notification> GetAllNotificationByFalse();
    void NotificationChangeToStatusTrue(int id);
    void NotificationChangeToStatusFalse(int id);
    
}