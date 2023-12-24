using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NoiThatStore.Models;

namespace NoiThatStore.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}

//using Microsoft.AspNetCore.Mvc;
//using NoiThatStore.Models;
//using NoiThatStore.Models.ViewModels;


//using System.Linq;
//namespace NoiThatStore.Controllers
//{
//    public class HomeController : Controller
//    {
//        private IStoreRepository repository;
//        public int PageSize = 4;
//        public HomeController(IStoreRepository repo)
//        {
//            repository = repo;
//        }
//        public ViewResult Index(int productPage = 1)
//        => View(new SanPhamListViewModel
//        {
//            Admins = repository.Admins
//            .OrderBy(p => p.ADMINID)
//            .Skip((productPage - 1) * PageSize)
//            .Take(PageSize),
//            PagingInfo = new PagingInfo
//            {
//                CurrentPage = productPage,
//                ItemsPerPage = PageSize,
//                TotalItems = repository.Admins.Count()
//            }
//        });
//    }
//}
