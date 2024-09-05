
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
