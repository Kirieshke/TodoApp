using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Interfaces;

namespace TodoApp.Core.Services
{
    public class TaskService: ITaskService
    {
        private readonly AppDbContext _appDbContext;
        private readonly DateTime date = DateTime.Today;
        public TaskService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
            
        public void Add(Entity.Task task)
        {
            _appDbContext.Add(task);
            _appDbContext.SaveChangesAsync();
            
        }

        public void Delete(int? id)
        {
            var task = _appDbContext.Tasks.FindAsync(id);
            if (task != null)
            {
                _appDbContext.Remove(task);
            }

            _appDbContext.SaveChangesAsync();

        }
       
        public List<Entity.Task> Details(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Task> GetTasks(int id)
        {
            var tasks = _appDbContext.Tasks.Include(p => p.Project).Where(p => p.ProjectId == id);
            return tasks.ToList();
        }

        public List<Entity.Task> GetTodayTasks()
        {
            var tasks = _appDbContext.Tasks.Include(t => t.Project).Where(p => p.Deadline.Date == date);
            return tasks.ToList();
        }

        public List<Entity.Task> GetUpcomingTasks()
        {
            var task = _appDbContext.Tasks.Include(t => t.Project).Where(p => p.Deadline.Date >= date);
            return task.ToList();
        }

        public List<Entity.Task> Search(string searchString)
        {
            var task = from m in _appDbContext.Tasks
                       select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                task = task.Where(s => s.Name!.Contains(searchString));
            }
            return task.ToList();
        }

        public void Update(Entity.Task task)
        {
            _appDbContext.Update(task);
            _appDbContext.SaveChangesAsync();
        }
    }
}
