using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using toDoListApp.Models;

namespace toDoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _db.ToDoItems.OrderByDescending(t => t.CreatedAt).ToListAsync();
            return View(tasks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public async Task<IActionResult> AddTask([Bind("Task")] ToDoItem newTask)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Task description is required and must be within 100 characters.";
                return RedirectToAction("Index");
            }

            _db.ToDoItems.Add(newTask);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Task added successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _db.ToDoItems.FindAsync(id);
            if (task == null)
            {
                TempData["Error"] = "Task not found!";
                return RedirectToAction("Index");
            }

            _db.ToDoItems.Remove(task);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Task removed successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            var task = await _db.ToDoItems.FindAsync(id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
