using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoiThatStore.Models;
using NoiThatStore.Infrastructure;
using NoiThatStoreAPI.Models;

namespace NoiThatStore.Pages
{
	public class CartModel : PageModel
	{
		private IStoreRepository repository;
		public CartModel(IStoreRepository repo, Cart cartService)
		{
			repository = repo;
			Cart = cartService;
		}
		public Cart Cart { get; set; }
		public string abc { get; set; }
		
		
		public string ReturnUrl { get; set; } = "/";
		public void OnGet(string returnUrl)
		{
			abc = "Get";
			
			ReturnUrl = returnUrl ?? "/Shop";
			
		}
		public IActionResult OnPost(long MASP, string returnUrl)
		{
			SanPham? product = repository.SanPhams
			.FirstOrDefault(p => p.MASP == MASP);
			if (product != null)
			{
	
				Cart.AddItem(product, 1);
				
			}
			return RedirectToPage(new { returnUrl = returnUrl });
		}

		public IActionResult OnPostTang(long MASP, string returnUrl)
		{
			SanPham? product = repository.SanPhams
			.FirstOrDefault(p => p.MASP == MASP);
			if (product != null)
			{

				Cart.AddItem(product, 1);

			}
			return RedirectToPage(new { returnUrl = returnUrl });
		}

		public IActionResult OnPostGiam(long MASP, string returnUrl)
		{
			SanPham? product = repository.SanPhams
			.FirstOrDefault(p => p.MASP == MASP);
			if (product != null)
			{

				Cart.GiamItem(product, -1);

			}
			return RedirectToPage(new { returnUrl = returnUrl });
		}

		public IActionResult OnPostRemove(long MASP, string returnUrl)
		{
			Cart.RemoveLine(Cart.Lines.First(cl =>
			cl.SanPham.MASP == MASP).SanPham);
			
			return RedirectToPage(new { returnUrl = returnUrl });
		}
		public IActionResult OnPostRemoveAll(string returnUrl)
		{
			Cart?.Clear();

			return RedirectToPage(new { returnUrl = returnUrl });
		}
	}
}
