﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Interfaces;

namespace TodoApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITaskService _taskService;
        private readonly DateTime date = DateTime.Today;
        public string taskJsonFile = "Maded_Tasks.json";
        public string taskFile = "Maded_Tasks.csv";
        public bool b = false;
        public TasksController(AppDbContext context, ITaskService taskService)
        {
            _context = context;
            _taskService = taskService;
        }
       
        // GET: Tasks
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var task = _taskService.Search(searchString);
            return View(task);    
        }
        public async Task<IActionResult> GetTasks(int id)
        {
            var appDbContext = _taskService.GetTasks(id);
            return View(appDbContext);
        }
        public async Task<IActionResult> GetTodayTasks()
        {
            var appDbContext = _taskService.GetTodayTasks();
            return View(appDbContext);
        }
        public async Task<IActionResult> GetUpcomingTasks()
        {
            var appDbContext = _context.Tasks.Include(t => t.Project).Where(p => p.Deadline.Date >= date);
            return View(await appDbContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Time,Deadline,IsDone,ProjectId")] Core.Entity.Task task)
        {
            _taskService.Add(task);
             return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", task.Id);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Time,IsDone,ProjectId")] Core.Entity.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _taskService.Update(task);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", task.Id);
            return View(task);
        }
        
        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }
            var task = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (task == null)
            {
                return NotFound();
            }
            
            if (task != null)
            {

                task.IsDone = true;
                task.serializeJson(task, taskJsonFile);
                task.deserializeJson(task, taskFile);
                _context.Tasks.Remove(task);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'AppDbContext.Tasks'  is null.");
            }
            _taskService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
          return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
