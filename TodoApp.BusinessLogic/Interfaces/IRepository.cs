using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Interfaces
{
    public interface IRepository<T>  where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetItem(int id);
        Task<T> Add(T item);
        ThreadTask.Task Update(T item, int id);
        ThreadTask.Task Delete(int id);
        ThreadTask.Task Save();
        void DataToJson();
    }
}
