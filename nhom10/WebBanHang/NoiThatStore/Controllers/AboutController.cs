using Microsoft.AspNetCore.Mvc;

namespace NoiThatStore.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
