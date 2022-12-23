using Application.Intefaces;
using Domain.InterfaceServices;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CommandStudentService : ICommandStudentService
    {
        private readonly ISchoolDbContext _dbContext;
        public CommandStudentService(ISchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> AddStudent(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            return student.ParentId;
        }

        public async Task DeleteStudent(Student student)
        {
            var entity = await _dbContext.Students.FindAsync(new object[] { student.StudentId });

            if (entity == null)
            {
                throw new Exception("NotFound " + student.StudentId.ToString());
            }

            _dbContext.Students.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudent()
        {
            var studentQuery = await _dbContext.Students.ToListAsync();

            return studentQuery;
        }
    }
}
