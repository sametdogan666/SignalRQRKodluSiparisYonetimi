using SignalR.Entities.Entities;

namespace SignalR.Business.Abstract;

public interface ICategoryService : IGenericService<Category>
{
    int GetCategoryCount();
    int GetActiveCategoryCount();
    int GetPassiveCategoryCount();
}