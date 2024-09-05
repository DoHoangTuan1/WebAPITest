using WebAPI.Data;
using WebAPI.Models;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Students = new Repository<Student>(_context);
        Addresses = new Repository<Address>(_context);
        Courses = new Repository<Course>(_context);
        Enrollments = new Repository<Enrollment>(_context);
    }

    public IRepository<Student> Students { get; private set; }
    public IRepository<Address> Addresses { get; private set; }
    public IRepository<Course> Courses { get; private set; }
    public IRepository<Enrollment> Enrollments { get; private set; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
