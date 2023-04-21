using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Interfaces
{
    public interface ITaskService: IRepository<Core.Entity.Task>
    {
        public List<Core.Entity.Task> Search(string searchString);
        public List<Core.Entity.Task> GetTasks(int id);
        public Task<Core.Entity.Task> GetTodayTasks();
        public Task<Core.Entity.Task> GetUpcomingTasks();
        public Task<Core.Entity.Task> Details(int? id);
        public Task<Core.Entity.Task> Add(Core.Entity.Task task);
        public Task<Core.Entity.Task> Update(Core.Entity.Task task);
        public Task<Core.Entity.Task> Delete(int? id);
    }
}
