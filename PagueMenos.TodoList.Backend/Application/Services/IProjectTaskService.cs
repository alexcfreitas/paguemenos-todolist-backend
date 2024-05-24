using PagueMenos.TodoList.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PagueMenos.TodoList.Application.Services
{
    public interface IProjectTaskService
    {
        Task<IEnumerable<ProjectTask>> GetAllProjectTasksAsync();
        Task<ProjectTask?> GetProjectTaskByIdAsync(int id);  // Permitir nullabilidade
        Task<ProjectTask> AddProjectTaskAsync(string title, string description);
        Task UpdateProjectTaskStatusAsync(int id, bool isCompleted);
        Task DeleteProjectTaskAsync(int id);
    }
}
