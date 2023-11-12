using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Abstract;

public interface INotificationDal : IGenericDal<Notification>
{
    int GetNotificationCountByStatusFalse();
    List<Notification> GetAllNotificationByFalse();
}