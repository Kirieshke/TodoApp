global using ThreadTask = System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TodoApp.Domain.Interfaces
{
    public class TaskRepository 
    {
        //private readonly AppDbContext _context;
        //public TaskRepository(AppDbContext context)
        //{
        //    _context = context;
        //}
        //public async Task<Domain.Task> Add(Task item)
        //{
        //    await _context.Tasks.AddAsync(item);
        //    return item;
        //}

        //public void DataToJson()
        //{
        //    throw new NotImplementedException();
        //}

        //public async ThreadTask.Task Delete(int id)
        //{
        //    var task = await _context.Tasks.FirstOrDefaultAsync(p => p.Id == id);
        //    if(task != null)
        //    {
        //        _context.Remove(task);
        //    }
        //}

        //public async Task<IEnumerable<Task>> GetAll()
        //{
        //    return await _context.Tasks.Include(p => p.Project).ToListAsync();
        //}

        //public async ThreadTask.Task<Task> GetItem(int id)
        //{
        //    return await _context.Tasks.FindAsync(id);
        //}

        //public async ThreadTask.Task Save()
        //{
        //    await _context.SaveChangesAsync();
        //}

        //public async ThreadTask.Task Update(Task item, int id)
        //{
        //    if (id == item.Id)
        //    {
        //         _context.Update(item);
        //         await _context.SaveChangesAsync();
        //    }

        //}
    }
}
