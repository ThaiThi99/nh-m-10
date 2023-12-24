using NoiThatStoreAPI.Models;

namespace NoiThatStore.Models
{
	public class Cart
	{
		public List<CartLine> Lines { get; set; } = new List<CartLine>();
		public virtual void AddItem(SanPham product, int quantity)
		{

			CartLine? line = Lines
			.Where(p => p.SanPham.MASP == product.MASP)
			.FirstOrDefault();
			if (line == null)
			{
				Lines.Add(new CartLine { SanPham = product, Quantity = quantity });
			}
			else
			{
				line.Quantity += quantity;
			}
		}
		public virtual void RemoveLine(SanPham product) => Lines.RemoveAll(l => l.SanPham.MASP == product.MASP);
		public decimal ComputeTotalValue() => Lines.Sum(e => (decimal)e.SanPham.GiaBan * e.Quantity);
		public virtual void Clear() => Lines.Clear();
	}
	public class CartLine
	{
		public int CartLineID { get; set; }
		public SanPham SanPham { get; set; } = new();
		public int Quantity { get; set; }
	}

}
