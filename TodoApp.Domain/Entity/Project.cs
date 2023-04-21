using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace TodoApp.Core.Entity
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [InverseProperty(nameof(Task.Project))]
        public virtual ICollection<Task>? Tasks { get; set; }
    }
}