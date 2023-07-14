using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDataRepository
    {
        List<TodoList> GetAllTasks();
        TodoList GetTaskById(string id);
        void AddTask(TodoList task);
        void UpdateTask(TodoList task);
        void DeleteTask(string id);
    }


    public class DatabaseRepository : IDataRepository
    {
        private ApplicationContext _context;

        public DatabaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<TodoList> GetAllTasks() => _context.Tasks.ToList();

        public TodoList GetTaskById(string id) => _context.Tasks.FirstOrDefault(t => t.Id == id);

        public void AddTask(TodoList task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(TodoList task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(string id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
