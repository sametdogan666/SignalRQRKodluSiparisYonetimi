using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
{
    public EfOrderDetailDal(SignalRContext context) : base(context)
    {
    }
}