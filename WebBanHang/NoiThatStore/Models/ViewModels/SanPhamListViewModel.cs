using NoiThatStoreAPI.Models;

namespace NoiThatStore.Models.ViewModels
{
    public class SanPhamListViewModel
    {
        public IEnumerable<Admin> Admins { get; set; } = Enumerable.Empty<Admin>();


        public PagingInfo PagingInfo { get; set; } = new();
    }
}
