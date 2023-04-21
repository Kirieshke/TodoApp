using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.Entity;

namespace TodoApp.ViewComponents
{
    [ViewComponent(Name = "Project")]
    public class ProjectViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public ProjectViewComponent(AppDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index", _context.Projects.ToList());
        }
    }
}
