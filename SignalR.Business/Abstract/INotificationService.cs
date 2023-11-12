using SignalR.Entities.Entities;

namespace SignalR.Business.Abstract;

public interface INotificationService : IGenericService<Notification>
{
    int GetNotificationCountByStatusFalse();
    List<Notification> GetAllNotificationByFalse();
}