using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfMessageDal : GenericRepository<Message>, IMessageDal
{
    public EfMessageDal(SignalRContext context) : base(context)
    {
    }
}