using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfBookingDal : GenericRepository<Booking>, IBookingDal
{
    public EfBookingDal(SignalRContext context) : base(context)
    {
    }

    public void BookingStatusApproved(int id)
    {
        using var context = new SignalRContext();
        var values = context.Bookings.Find(id);
        values.Description = "Rezervasyon Onaylandı";
        context.SaveChanges();

    }

    public void BookingStatusCanceled(int id)
    {
        using var context = new SignalRContext();
        var values = context.Bookings.Find(id);
        values.Description = "Rezervasyon İptal Edildi";
        context.SaveChanges();
    }
}