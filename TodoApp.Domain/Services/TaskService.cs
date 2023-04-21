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
        public TaskService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
            
        public Task<Entity.Task> Add(Entity.Task task)
        {
            throw new NotImplementedException();
        }

        public Task<Entity.Task> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Entity.Task> Details(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Task> GetTasks(int id)
        {
            var appDbContext = _appDbContext.Tasks.Include(p => p.Project).Where(p => p.ProjectId == id);
            return appDbContext.ToList();
        }

        public Task<Entity.Task> GetTodayTasks()
        {
            throw new NotImplementedException();
        }

        public Task<Entity.Task> GetUpcomingTasks()
        {
            throw new NotImplementedException();
        }

        public List<Entity.Task> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public Task<Entity.Task> Update(Entity.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
