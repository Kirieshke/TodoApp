using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Core;
using TodoApp.Core.Entity;

namespace TodoApp.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Projects.ToListAsync();
            return View(await appDbContext);
        }
        public async Task<IActionResult> GetProject(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.Include(p => p.Project).FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name")] Project project)
        {
            if(ModelState.IsValid)
            {
                _context.AddAsync(project);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(project);
        }

    }
}
