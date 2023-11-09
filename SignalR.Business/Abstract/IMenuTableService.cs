using SignalR.Entities.Entities;

namespace SignalR.Business.Abstract;

public interface IMenuTableService : IGenericService<MenuTable>
{
    int GetMenuTableCount();
}