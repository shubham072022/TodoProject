using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoProject.Data;
using TodoProject.Models;

namespace TodoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TodoController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("")]
        public async Task<List<TaskMaster>> GetAll()
        {
            return _db.Tasks.OrderByDescending(t => t.Id).ToList();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<bool> Add(TaskMaster model)
        {
            _db.Tasks.Add(model);
            _db.SaveChanges();
            return true;
        }

        [HttpPost]
        [Route("doneundone")]
        public async Task<bool> Update(TaskMaster model)
        {
            var task = _db.Tasks.SingleOrDefault(t => t.Id == model.Id);
            task.IsDone = !task.IsDone;
            _db.SaveChanges();
            return true;
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<bool> Delete(TaskMaster model)
        {
            var task = _db.Tasks.SingleOrDefault(t => t.Id == model.Id);
            _db.Tasks.Remove(task);
            _db.SaveChanges();
            return true;
        }
    }
}
