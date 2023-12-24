using NoiThatStoreAPI.Models;

namespace NoiThatStore.Models.ViewModels
{
	public class ProductsListViewModel
	{
		public IEnumerable<SanPham> SanPhams { get; set; } = Enumerable.Empty<SanPham>();

        public PagingInfo PagingInfo { get; set; } = new();
		public string? CurrentCategory { get; set; }

	
	}
}
