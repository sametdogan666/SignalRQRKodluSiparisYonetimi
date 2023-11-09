using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entities.Entities;

namespace SignalR.Business.Concrete;

public class MenuTableManager : IMenuTableService
{
    private readonly IMenuTableDal _menuTableDal;

    public MenuTableManager(IMenuTableDal menuTableDal)
    {
        _menuTableDal = menuTableDal;
    }

    public void Add(MenuTable entity)
    {
        _menuTableDal.Add(entity);
    }

    public void Remove(MenuTable entity)
    {
        _menuTableDal.Remove(entity);
    }

    public void Update(MenuTable entity)
    {
        _menuTableDal.Update(entity);
    }

    public MenuTable? GetById(int id)
    {
        return _menuTableDal.GetById(id);
    }

    public List<MenuTable> GetAll()
    {
        return _menuTableDal.GetAll();
    }

    public int GetMenuTableCount()
    {
        return _menuTableDal.GetMenuTableCount();
    }
}