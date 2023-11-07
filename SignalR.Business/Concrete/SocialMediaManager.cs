using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class SocialMediaManager : ISocialMediaService
{
    private readonly ISocialMediaDal _socialMediaDal;

    public SocialMediaManager(ISocialMediaDal socialMediaDal)
    {
        _socialMediaDal = socialMediaDal;
    }

    public void Add(SocialMedia entity)
    {
        _socialMediaDal.Add(entity);
    }

    public void Remove(SocialMedia entity)
    {
        _socialMediaDal.Remove(entity);
    }

    public void Update(SocialMedia entity)
    {
        _socialMediaDal.Update(entity);
    }

    public SocialMedia? GetById(int id)
    {
        return _socialMediaDal.GetById(id);
    }

    public List<SocialMedia> GetAll()
    {
        return _socialMediaDal.GetAll();
    }
}