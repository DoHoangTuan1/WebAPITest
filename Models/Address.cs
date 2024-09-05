using System.ComponentModel.DataAnnotations;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
