
using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
