using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class MessageManager : IMessageService
{
    private readonly IMessageDal _messageDal;

    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }

    public void Add(Message entity)
    {
        _messageDal.Add(entity);
    }

    public void Remove(Message entity)
    {
        _messageDal.Remove(entity);
    }

    public void Update(Message entity)
    {
        _messageDal.Update(entity);
    }

    public Message? GetById(int id)
    {
        return _messageDal.GetById(id);
    }

    public List<Message> GetAll()
    {
        return _messageDal.GetAll();
    }
}