using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Abstract;

public interface IMenuTableDal : IGenericDal<MenuTable>
{
    int GetMenuTableCount();
}