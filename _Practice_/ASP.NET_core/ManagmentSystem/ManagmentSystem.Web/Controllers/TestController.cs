using Microsoft.AspNetCore.Mvc;
using ManagmentSystem.Web.Models;

namespace ManagmentSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult About()
        {
            var model = new TestViewModel { Name = "Martin", DateOfBirth = new DateTime(2010, 8, 12) };
            return View(model);
        }
    }
}
