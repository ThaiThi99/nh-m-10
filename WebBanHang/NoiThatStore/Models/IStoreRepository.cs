using NoiThatStoreAPI.Models;


namespace NoiThatStore.Models
{
	public interface IStoreRepository
	{
        IQueryable<SanPham> SanPhams { get; }
        void SaveSanPham(SanPham p);
        void CreateSanPham(SanPham p);
        void DeleteSanPham(SanPham p);

        IQueryable<Admin> Admins { get; }
        void SaveAdmin(Admin p);
        void CreateAdmin(Admin p);
        void DeleteAdmin(Admin p);


		IQueryable<Order> Orders { get; }
		void SaveOrder(Order p);
		void CreateOrder(Order p);
		void DeleteOrder(Order p);

		IQueryable<HoaDon> HoaDons { get; }
		void SaveHoaDon(HoaDon p);
		void CreateHoaDon(HoaDon p);
		void DeleteHoaDon(HoaDon p);

		IQueryable<HoaDonCT> HoaDonCTs { get; }
		void SaveHoaDonCT(HoaDonCT p);
		void CreateHoaDonCT(HoaDonCT p);
		void DeleteHoaDonCT(HoaDonCT p);

		IQueryable<KhachHang> KhachHangs { get; }
		void SaveKhachHang(KhachHang p);
		void CreateKhachHang(KhachHang p);
		void DeleteKhachHang(KhachHang p);

		IQueryable<NhaCungCap> NhaCungCaps { get; }
		void SaveNhaCungCap(NhaCungCap p);
		void CreateNhaCungCap(NhaCungCap p);
		void DeleteNhaCungCap(NhaCungCap p);
	}
}

