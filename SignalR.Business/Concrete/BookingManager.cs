using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class BookingManager : IBookingService
{
    private readonly IBookingDal _bookingDal;

    public BookingManager(IBookingDal bookingDal)
    {
        _bookingDal = bookingDal;
    }

    public void Add(Booking entity)
    {
        _bookingDal.Add(entity);
    }

    public void Remove(Booking entity)
    {
        _bookingDal.Remove(entity);
    }

    public void Update(Booking entity)
    {
        _bookingDal.Update(entity);
    }

    public Booking? GetById(int id)
    {
        return _bookingDal.GetById(id);
    }

    public List<Booking> GetAll()
    {
        return _bookingDal.GetAll();
    }

    public void BookingStatusApproved(int id)
    {
        _bookingDal.BookingStatusApproved(id);
    }

    public void BookingStatusCanceled(int id)
    {
        _bookingDal.BookingStatusCanceled(id);
    }
}