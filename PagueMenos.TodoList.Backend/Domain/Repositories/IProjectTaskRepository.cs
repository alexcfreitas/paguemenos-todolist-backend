using PagueMenos.TodoList.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PagueMenos.TodoList.Domain.Repositories
{
    public interface IProjectTaskRepository
    {
        Task<ProjectTask?> GetByIdAsync(int id);  // Permitir nullabilidade
        Task<IEnumerable<ProjectTask>> GetAllAsync();
        Task AddAsync(ProjectTask projectTask);
        Task UpdateAsync(ProjectTask projectTask);
        Task DeleteAsync(int id);
    }
}
