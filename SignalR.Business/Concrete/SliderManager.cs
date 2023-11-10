using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class SliderManager : ISliderService
{
    private readonly ISliderDal _sliderDal;

    public SliderManager(ISliderDal sliderDal)
    {
        _sliderDal = sliderDal;
    }

    public void Add(Slider entity)
    {
        _sliderDal.Add(entity);
    }

    public void Remove(Slider entity)
    {
        _sliderDal.Remove(entity);
    }

    public void Update(Slider entity)
    {
        _sliderDal.Update(entity);
    }

    public Slider? GetById(int id)
    {
        return _sliderDal.GetById(id);
    }

    public List<Slider> GetAll()
    {
        return _sliderDal.GetAll();
    }
}