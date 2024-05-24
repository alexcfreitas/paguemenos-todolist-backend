namespace PagueMenos.TodoList.Domain.Entities
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public ProjectTask(string title, string description)
        {
            Title = title;
            Description = description;
            IsCompleted = false;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public void MarkAsNotCompleted()
        {
            IsCompleted = false;
        }
    }
}
