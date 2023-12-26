using Microsoft.AspNetCore.Mvc;

namespace NoiThatStore.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
