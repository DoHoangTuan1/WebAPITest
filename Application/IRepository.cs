
namespace Application;
public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAllAsync();
    T GetByIdAsync(int id);
    void InsertAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(int id);
    void AddAsync<T>(T entity) where T : class;
}