namespace Domain.Models
{
    public class Parent
    {
        public Guid ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string Phone { get; set; }
        public string WorkPhone { get; set; }
        public int Sibilings { get; set; }
    }
}
