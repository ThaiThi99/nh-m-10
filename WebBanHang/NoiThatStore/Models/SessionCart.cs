using System.Text.Json.Serialization;
using NoiThatStore.Infrastructure;
using NoiThatStoreAPI.Models;

namespace NoiThatStore.Models
{
	public class SessionCart : Cart
	{
		public static Cart GetCart(IServiceProvider services)
		{
			ISession? session = services.GetRequiredService<IHttpContextAccessor>()
			.HttpContext?.Session;
			SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
			cart.Session = session;
			return cart;
		}
		[JsonIgnore]
		public ISession? Session { get; set; }
		public override void AddItem(SanPham product, int quantity)
		{
			base.AddItem(product, quantity);
			Session?.SetJson("Cart", this);
		}
		public override void RemoveLine(SanPham product)
		{
			base.RemoveLine(product);
			Session?.SetJson("Cart", this);
		}
		public override void Clear()
		{
			base.Clear();
			Session?.Remove("Cart");
		}
	}
}