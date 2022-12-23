using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Intefaces
{
    public interface ISchoolDbContext
    {
        DbSet<Parent> Parents { get; set; }
        DbSet<Student> Students { get; set; }
        Task<int> SaveChangesAsync();
    }
}
