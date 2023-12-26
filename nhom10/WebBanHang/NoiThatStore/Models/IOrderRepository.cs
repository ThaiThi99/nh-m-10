using NoiThatStoreAPI.Models;
namespace NoiThatStore.Models
{
	public interface IOrderRepository
	{
		IQueryable<Order> Orders { get; }
		void SaveOrder(Order order);
        IQueryable<HoaDon> HoaDons { get; }
        void SaveHoaDon(HoaDon hoadon);

        IQueryable<HoaDonCT> HoaDonCTs { get; }
        void SaveHoaDonCT(HoaDonCT hoadonCT);

    }
}