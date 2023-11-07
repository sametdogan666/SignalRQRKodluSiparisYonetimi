using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public void Add(About entity)
    {
       _aboutDal.Add(entity);
    }

    public void Remove(About entity)
    {
        _aboutDal.Remove(entity);
    }

    public void Update(About entity)
    {
        _aboutDal.Update(entity);
    }

    public About? GetById(int id)
    {
       return _aboutDal.GetById(id);
    }

    public List<About> GetAll()
    {
       return _aboutDal.GetAll();
    }
}