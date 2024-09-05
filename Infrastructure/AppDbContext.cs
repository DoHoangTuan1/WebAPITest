using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // Configure one-to-many relationship
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<Address>(a => a.StudentId);

            // Seed data for Students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "John Doe" },
                new Student { StudentId = 2, Name = "Jane Smith" }
            );

            // Seed data for Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Title = "Mathematics" },
                new Course { CourseId = 2, Title = "Science" }
            );

            // Seed data for Addresses
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId = 1, StudentId = 1, Street = "123 Main St", City = "Anytown" },
                new Address { AddressId = 2, StudentId = 2, Street = "456 Oak St", City = "Othertown" }
            );

            // Seed data for Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { StudentId = 1, CourseId = 1 },
                new Enrollment { StudentId = 2, CourseId = 2 }
            );
        }
    }
}
