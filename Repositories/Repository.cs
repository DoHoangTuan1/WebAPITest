using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _entities;

    public Repository(AppDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public IEnumerable<T> GetAllAsync()
    {
        return _entities.ToList();
    }

    public T GetByIdAsync(int id)
    {
        return _entities.Find(id);
    }

    public void InsertAsync(T entity)
    {
        _entities.Add(entity);
    }

    public void UpdateAsync(T entity)
    {
        _entities.Update(entity);
    }

    public void DeleteAsync(int id)
    {
        T entity = _entities.Find(id);
        _entities.Remove(entity);
    }

    public void AddAsync<T1>(T1 entity) where T1 : class
    {
        throw new NotImplementedException();
    }
}
