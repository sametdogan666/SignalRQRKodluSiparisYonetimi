using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Abstract;

public interface ICategoryDal : IGenericDal<Category>
{
    int GetCategoryCount();
    int GetActiveCategoryCount();
    int GetPassiveCategoryCount();

}