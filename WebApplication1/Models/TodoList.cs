namespace WebApplication1.Models
{
    public class TodoList
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }
    }

}
