using Domain.Models;

namespace Domain.InterfaceServices
{
    public interface ICommandStudentService
    {
        Task<Guid> AddStudent(Student student);
        Task DeleteStudent(Student student);
        Task<List<Student>> GetAllStudent();
    }
}
