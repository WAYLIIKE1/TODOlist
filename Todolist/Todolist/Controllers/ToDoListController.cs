using Microsoft.AspNetCore.Mvc;

namespace Todolist.Controllers
{
    public class ToDoListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
