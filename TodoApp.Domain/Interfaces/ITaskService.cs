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
        public List<Entity.Task> GetTodayTasks();
        public List<Entity.Task> GetUpcomingTasks();
        public List<Entity.Task> Details(int? id);
        public void Add(Core.Entity.Task task);
        public void Update(Core.Entity.Task task);
        public void Delete(int? id);
    }
}
