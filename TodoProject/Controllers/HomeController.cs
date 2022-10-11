using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoProject.Data;
using TodoProject.Models;

namespace TodoProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var tasks = _db.Tasks.ToList();
            return View(tasks);
        }
        public IActionResult TasksWithJs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoneUndone(TaskMaster model)
        {
            if (model != null)
            {
                var task = _db.Tasks.SingleOrDefault(t => t.Id == model.Id);
                task.IsDone = !task.IsDone;
                _db.SaveChanges();
            }
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult Todo(TaskMaster model)
        {
            _db.Tasks.Add(model);
            _db.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}