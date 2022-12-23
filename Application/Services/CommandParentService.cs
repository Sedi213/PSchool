using Application.Intefaces;
using Domain.InterfaceServices;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Application.Services
{
    public class CommandParentService : ICommandParentService
    {
        private readonly ISchoolDbContext _dbContext;
        public CommandParentService(ISchoolDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task<Guid> AddParent(Parent parent)
        {
            await _dbContext.Parents.AddAsync(parent);
            await _dbContext.SaveChangesAsync();

            return parent.ParentId;
        }

        public async Task DeleteParent(Parent parent)
        {
            var entity = await _dbContext.Parents.FindAsync(new object[] { parent.ParentId });

            if (entity == null)
            {
                throw new Exception("NotFound " + parent.ParentId.ToString());
            }

            _dbContext.Parents.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Parent>> GetAllParent()
        {
            var parentsQuery = await _dbContext.Parents.ToListAsync();


            return parentsQuery;
        }
    }
}
