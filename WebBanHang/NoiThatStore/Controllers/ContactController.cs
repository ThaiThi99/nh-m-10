using Microsoft.AspNetCore.Mvc;

namespace NoiThatStore.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
