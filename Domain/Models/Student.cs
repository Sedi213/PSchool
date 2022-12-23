
namespace Domain.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public Guid ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
