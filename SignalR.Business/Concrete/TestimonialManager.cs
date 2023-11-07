using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class TestimonialManager : ITestimonialService
{
    private readonly ITestimonialDal _testimonialDal;

    public TestimonialManager(ITestimonialDal testimonialDal)
    {
        _testimonialDal = testimonialDal;
    }

    public void Add(Testimonial entity)
    {
        _testimonialDal.Add(entity);
    }

    public void Remove(Testimonial entity)
    {
        _testimonialDal.Remove(entity);
    }

    public void Update(Testimonial entity)
    {
        _testimonialDal.Update(entity);
    }

    public Testimonial? GetById(int id)
    {
        return _testimonialDal.GetById(id);
    }

    public List<Testimonial> GetAll()
    {
        return _testimonialDal.GetAll();
    }
}