using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfSliderDal : GenericRepository<Slider>, ISliderDal
{
    public EfSliderDal(SignalRContext context) : base(context)
    {
    }
}