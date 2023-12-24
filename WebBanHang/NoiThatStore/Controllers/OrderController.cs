using Microsoft.AspNetCore.Mvc;
using NoiThatStore.Models;
using NoiThatStoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoiThatStore.Pages.Admin;

namespace NoiThatStore.Controllers
{
	public class OrderController : Controller
	{
        private readonly UserManager<IdentityUser> _userManager;
        private IOrderRepository repository;

        private Cart cart;
		public OrderController(IOrderRepository repoService, Cart cartService, UserManager<IdentityUser> userManager)
		{
            repository = repoService;
			cart = cartService;
            _userManager = userManager;
        }
		public ViewResult Checkout() => View(new Order());
		[HttpPost]
		public async Task<IActionResult> Checkout(Order order)
		{
            var username = User.Identity.Name;

            if(username == null)
            {
                return Redirect("/identity/account/Login");
            }

            // Tìm người dùng trong UserManager bằng username
            var user = await _userManager.FindByNameAsync(username);
         
            if (cart.Lines.Count() == 0)
			{
				ModelState.AddModelError("", "Sorry, your cart is empty!");
			}
			if (ModelState.IsValid)
			{
                    order.Lines = cart.Lines.ToArray();
                    repository.SaveOrder(order);
                    // Gán MAKH_id của HoaDon bằng id của người dùng

                    HoaDon hoaDon = new HoaDon
                    {
                        MAKH_id = int.Parse(user.Id),
                        //GIABAN = order.TotalPrice,
                        GIABAN = (decimal?)(order.Lines?.Sum(line => (decimal)line.SanPham.GiaBan * line.Quantity)) ?? 0,

                        NGAYHD = DateTime.Now,
                        LOAIHD = "Online" // Giả sử mặc định là "Online"
                    };
                    repository.SaveHoaDon(hoaDon);
                    foreach (var line in order.Lines)
                    {
                        HoaDonCT hoaDonCT = new HoaDonCT
                        {
                            MAHD = hoaDon.MAHD,
                            MASP = line.SanPham.MASP,
                            SL = line.Quantity,
                            DONGIA = (decimal)line.SanPham.GiaBan
                        };
                        repository.SaveHoaDonCT(hoaDonCT);
                    }
                
                //}
                //else return RedirectToPage("./Login");




                // Lưu đối tượng HoaDon vào cơ sở dữ liệu


                cart.Clear();
				return RedirectToPage("/Completed", new { orderId = order.OrderID });
			}
			else
			{
				return View();
			}
		}
	}
}
