using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public void Add(Category entity)
    {
        _categoryDal.Add(entity);
    }

    public void Remove(Category entity)
    {
       _categoryDal.Remove(entity);
    }

    public void Update(Category entity)
    {
        _categoryDal.Update(entity);
    }

    public Category? GetById(int id)
    {
        return _categoryDal.GetById(id);
    }

    public List<Category> GetAll()
    {
        return _categoryDal.GetAll();
    }
}