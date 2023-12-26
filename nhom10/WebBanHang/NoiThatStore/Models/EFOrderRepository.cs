using Microsoft.EntityFrameworkCore;
using NoiThatStore.Models;
using NoiThatStoreAPI.Models;

namespace SportsStore.Models
{
	public class EFOrderRepository : IOrderRepository
	{
		private StoreDbContext context;
		public EFOrderRepository(StoreDbContext ctx)
		{
			context = ctx;
		}
		public IQueryable<Order> Orders => context.Orders
		.Include(o => o.Lines)
		.ThenInclude(l => l.SanPham);
		public void SaveOrder(Order order)
		{
			context.AttachRange(order.Lines.Select(l => l.SanPham));
			if (order.OrderID == 0)
			{
				context.Orders.Add(order);
			}
			context.SaveChanges();
		}

		public IQueryable<HoaDon> HoaDons => context.HoaDons;

        public void SaveHoaDon(HoaDon p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public IQueryable<HoaDonCT> HoaDonCTs => context.HoaDonCTs;

        public void SaveHoaDonCT(HoaDonCT p)
        {
            context.Add(p);
            context.SaveChanges();
        }
    }
}
