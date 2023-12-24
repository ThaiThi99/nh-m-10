using NoiThatStoreAPI.Models;

namespace NoiThatStore.Models
{
	public class EFStoreRepository : IStoreRepository
	{
		private StoreDbContext context;
		public EFStoreRepository(StoreDbContext ctx)
		{
			context = ctx;
		}
        public IQueryable<SanPham> SanPhams => context.SanPhams;

        public void CreateSanPham(SanPham p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteSanPham(SanPham p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveSanPham(SanPham p)
        {
            context.SaveChanges();
        }


        public IQueryable<Admin> Admins => context.Admins;

        public void CreateAdmin(Admin p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteAdmin(Admin p)
        {
            context.Remove(p);

            context.SaveChanges();
        }
        public void SaveAdmin(Admin p)
        {
            context.SaveChanges();
        }

		public IQueryable<Order> Orders => context.Orders;

		public void CreateOrder(Order p)
		{
			context.Add(p);
			context.SaveChanges();
		}
		public void DeleteOrder(Order p)
		{
			context.Remove(p);

			context.SaveChanges();
		}
		public void SaveOrder(Order p)
		{
			context.SaveChanges();
		}

		public IQueryable<HoaDon> HoaDons => context.HoaDons;

		public void CreateHoaDon(HoaDon p)
		{
			context.Add(p);
			context.SaveChanges();
		}
		public void DeleteHoaDon(HoaDon p)
		{
			context.Remove(p);

			context.SaveChanges();
		}
		public void SaveHoaDon(HoaDon p)
		{
			context.SaveChanges();
		}

		public IQueryable<HoaDonCT> HoaDonCTs => context.HoaDonCTs;

		public void CreateHoaDonCT(HoaDonCT p)
		{
			context.Add(p);
			context.SaveChanges();
		}
		public void DeleteHoaDonCT(HoaDonCT p)
		{
			context.Remove(p);

			context.SaveChanges();
		}
		public void SaveHoaDonCT(HoaDonCT p)
		{
			context.SaveChanges();
		}

		public IQueryable<KhachHang> KhachHangs => context.KhachHangs;

		public void CreateKhachHang(KhachHang p)
		{
			context.Add(p);
			context.SaveChanges();
		}
		public void DeleteKhachHang(KhachHang p)
		{
			context.Remove(p);

			context.SaveChanges();
		}
		public void SaveKhachHang(KhachHang p)
		{
			context.SaveChanges();
		}

		public IQueryable<NhaCungCap> NhaCungCaps => context.NhaCungCaps;

		public void CreateNhaCungCap(NhaCungCap p)
		{
			context.Add(p);
			context.SaveChanges();
		}
		public void DeleteNhaCungCap(NhaCungCap p)
		{
			context.Remove(p);

			context.SaveChanges();
		}
		public void SaveNhaCungCap(NhaCungCap p)
		{
			context.SaveChanges();
		}

	}
}
