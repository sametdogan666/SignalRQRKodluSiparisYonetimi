using SignalR.Entities.Entities;

namespace SignalR.Business.Abstract;

public interface IBookingService : IGenericService<Booking>
{
    void BookingStatusApproved(int id);
    void BookingStatusCanceled(int id);
}