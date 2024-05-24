using Microsoft.EntityFrameworkCore;
using PagueMenos.TodoList.Domain.Entities;
using PagueMenos.TodoList.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PagueMenos.TodoList.Infrastructure.Data
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly ProjectTaskContext _context;

        public ProjectTaskRepository(ProjectTaskContext context)
        {
            _context = context;
        }

        public async Task<ProjectTask?> GetByIdAsync(int id)  // Permitir nullabilidade
        {
            return await _context.ProjectTasks.FindAsync(id);
        }

        public async Task<IEnumerable<ProjectTask>> GetAllAsync()
        {
            return await _context.ProjectTasks.ToListAsync();
        }

        public async Task AddAsync(ProjectTask projectTask)
        {
            await _context.ProjectTasks.AddAsync(projectTask);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjectTask projectTask)
        {
            _context.ProjectTasks.Update(projectTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var projectTask = await _context.ProjectTasks.FindAsync(id);
            if (projectTask != null)
            {
                _context.ProjectTasks.Remove(projectTask);
                await _context.SaveChangesAsync();
            }
        }
    }
}
