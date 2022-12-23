using Application.Intefaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SchoolDbContext : DbContext, ISchoolDbContext
    {
        public DbSet<Parent> Parents { get; set ; }
        public DbSet<Student> Students { get ; set ; }
        public SchoolDbContext(DbContextOptions option):base(option)
        {
            Database.EnsureCreated();
        }
       public async Task<int> SaveChangesAsync()//interface doesnt see base class method
        {
            return await base.SaveChangesAsync();
        }
    }
}
