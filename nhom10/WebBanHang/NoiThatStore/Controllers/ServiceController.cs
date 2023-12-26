using Microsoft.AspNetCore.Mvc;

namespace NoiThatStore.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
