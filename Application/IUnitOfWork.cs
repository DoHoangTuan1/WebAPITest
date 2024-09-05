
using Domain;
namespace Application;
public interface IUnitOfWork : IDisposable
{
    IRepository<Student> Students { get; }
    IRepository<Address> Addresses { get; }
    IRepository<Course> Courses { get; }
    IRepository<Enrollment> Enrollments { get; }
    int Complete();
}
