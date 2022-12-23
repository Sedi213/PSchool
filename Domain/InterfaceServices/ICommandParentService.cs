using Domain.Models;

namespace Domain.InterfaceServices
{
    public interface ICommandParentService
    {
        Task<Guid> AddParent(Parent parent);
        Task DeleteParent(Parent parent);
        Task<List<Parent>> GetAllParent();
    }
}
