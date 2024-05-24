using PagueMenos.TodoList.Domain.Entities;
using PagueMenos.TodoList.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PagueMenos.TodoList.Application.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _projectTaskRepository;

        public ProjectTaskService(IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task<IEnumerable<ProjectTask>> GetAllProjectTasksAsync()
        {
            return await _projectTaskRepository.GetAllAsync();
        }

        public async Task<ProjectTask?> GetProjectTaskByIdAsync(int id)  // Permitir nullabilidade
        {
            return await _projectTaskRepository.GetByIdAsync(id);
        }

        public async Task<ProjectTask> AddProjectTaskAsync(string title, string description)
        {
            var projectTask = new ProjectTask(title, description);
            await _projectTaskRepository.AddAsync(projectTask);
            return projectTask;
        }

        public async Task UpdateProjectTaskStatusAsync(int id, bool isCompleted)
        {
            var projectTask = await _projectTaskRepository.GetByIdAsync(id);
            if (projectTask == null)
            {
                throw new ArgumentException($"ProjectTask with id {id} not found");
            }
            if (isCompleted)
            {
                projectTask.MarkAsCompleted();
            }
            else
            {
                projectTask.MarkAsNotCompleted();
            }
            await _projectTaskRepository.UpdateAsync(projectTask);
        }

        public async Task DeleteProjectTaskAsync(int id)
        {
            await _projectTaskRepository.DeleteAsync(id);
        }
    }
}
