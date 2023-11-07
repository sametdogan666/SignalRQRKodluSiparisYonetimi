using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;

namespace SignalR.DataAccess.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
{

    private readonly SignalRContext _context;

    public GenericRepository(SignalRContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Remove(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Update(entity);
        _context.SaveChanges();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
}