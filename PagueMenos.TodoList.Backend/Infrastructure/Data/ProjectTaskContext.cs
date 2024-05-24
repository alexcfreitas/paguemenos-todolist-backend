using Microsoft.EntityFrameworkCore;
using PagueMenos.TodoList.Domain.Entities;

namespace PagueMenos.TodoList.Infrastructure.Data
{
    public class ProjectTaskContext : DbContext
    {
        public ProjectTaskContext(DbContextOptions<ProjectTaskContext> options) : base(options) { }

        public DbSet<ProjectTask> ProjectTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTask>().HasKey(t => t.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
