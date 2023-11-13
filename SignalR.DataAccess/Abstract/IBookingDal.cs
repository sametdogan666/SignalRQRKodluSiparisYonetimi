using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Abstract;

public interface IBookingDal : IGenericDal<Booking>
{
    void BookingStatusApproved(int id);
    void BookingStatusCanceled(int id);
}