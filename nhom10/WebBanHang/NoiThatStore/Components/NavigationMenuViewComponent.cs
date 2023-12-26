using Microsoft.AspNetCore.Mvc;
using NoiThatStore.Models;
namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository repository;
        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
			ViewBag.SelectedCategory = RouteData?.Values["category"];
			return View(repository.SanPhams
            .Select(x => x.LOAI)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
