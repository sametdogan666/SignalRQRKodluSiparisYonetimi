using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
{
    public EfCategoryDal(SignalRContext context) : base(context)
    {
    }

    public int GetCategoryCount()
    {
        using var context = new SignalRContext();

        return context.Categories.Count();
    }

    public int GetActiveCategoryCount()
    {
        using var context = new SignalRContext();

        return context.Categories.Where(x => x.Status == true).Count();
    }

    public int GetPassiveCategoryCount()
    {
        using var context = new SignalRContext();

        return context.Categories.Where(x => x.Status == false).Count();
    }
}