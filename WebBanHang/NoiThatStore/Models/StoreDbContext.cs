using NoiThatStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace NoiThatStore.Models
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options)
		: base(options) { }
        public DbSet<SanPham> SanPhams => Set<SanPham>();
		public DbSet<Admin> Admins => Set<Admin>();
		public DbSet<Order> Orders => Set<Order>();
		public DbSet<HoaDon> HoaDons => Set<HoaDon>();
		public DbSet<HoaDonCT> HoaDonCTs => Set<HoaDonCT>();
		public DbSet<KhachHang> KhachHangs => Set<KhachHang>();
		public DbSet<NhaCungCap> NhaCungCaps => Set<NhaCungCap>();
	}
}
