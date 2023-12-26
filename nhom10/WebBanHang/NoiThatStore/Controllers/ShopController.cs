
using Microsoft.AspNetCore.Mvc;
using NoiThatStore.Models;
using NoiThatStore.Models.ViewModels;
using NoiThatStore.Pages.Admin;
using NoiThatStoreAPI.Models;
using System.Linq;

namespace NoiThatStore.Controllers
{
    public class ShopController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 8;

        public ShopController(IStoreRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
      
        public ViewResult Index(string category, int productPage = 1)
        {
            var products = repository.SanPhams
                .Where(p => category == null || p.LOAI == category)
                .OrderBy(p => p.MASP)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var totalItems = repository.SanPhams
                .Count(p => category == null || p.LOAI == category);

          

            var viewModel = new ProductsListViewModel
            {
                SanPhams = products,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = totalItems
                },
                CurrentCategory = category,
              
            };

            var sp = from SanPham in repository.SanPhams select SanPham;
            //var sp = repository.SanPhams.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                sp = sp.Where(x => x.TENSP.Contains(category));
            }

            return View(viewModel);
        }
        public async Task<IActionResult> Details(long MASP) 
        {
            if(MASP == null) return RedirectToAction("Index");
            var id = repository.SanPhams.Where(p => p.MASP == MASP).FirstOrDefault();
            return View(id);
        }
        #region hinh anh
        //public ActionResult ThemAnh(long id)
        //{
        //    //ViewBag.erro = id;
        //    ViewBag.id = id;
        //    return View();
        //}

        #endregion
    }
}