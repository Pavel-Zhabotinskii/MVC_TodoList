using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class TaskController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public TaskController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            return View(_dataRepository.GetAllTasks());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TodoList task)
        {
            // Добавьте новую задачу в список
            _dataRepository.AddTask(task);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            // Найдите задачу по идентификатору и передайте ее в представление для редактирования
            var task = _dataRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TodoList task)
        {
            // Найдите задачу по идентификатору и обновите ее значения
            var existingTask = _dataRepository.GetTaskById(task.Id);
            if (existingTask == null)
            {
                return NotFound();
            }
            existingTask.Title = task.Title;
            existingTask.IsCompleted = task.IsCompleted;
            _dataRepository.UpdateTask(existingTask);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            _dataRepository.DeleteTask(id);
            return RedirectToAction("Index");
        }

    }
}