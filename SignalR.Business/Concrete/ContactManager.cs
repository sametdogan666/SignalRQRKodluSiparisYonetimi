using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void Add(Contact entity)
    {
        _contactDal.Add(entity);
    }

    public void Remove(Contact entity)
    {
        _contactDal.Remove(entity);
    }

    public void Update(Contact entity)
    {
        _contactDal.Update(entity);
    }

    public Contact? GetById(int id)
    {
        return _contactDal.GetById(id);
    }

    public List<Contact> GetAll()
    {
        return _contactDal.GetAll();
    }
}