using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class FeatureManager : IFeatureService
{
    private readonly IFeatureDal _featureDal;

    public FeatureManager(IFeatureDal featureDal)
    {
        _featureDal = featureDal;
    }

    public void Add(Feature entity)
    {
        _featureDal.Add(entity);
    }

    public void Remove(Feature entity)
    {
        _featureDal.Remove(entity);
    }

    public void Update(Feature entity)
    {
        _featureDal.Update(entity);
    }

    public Feature? GetById(int id)
    {
        return _featureDal.GetById(id);
    }

    public List<Feature> GetAll()
    {
        return _featureDal.GetAll();
    }
}