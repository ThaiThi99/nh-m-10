using Microsoft.EntityFrameworkCore;
namespace NoiThatStoreAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>()
                .HasIndex(a => a.TEN_TK)
                .IsUnique();

            modelBuilder.Entity<SanPham>()
            .HasOne(x => x.NhaCungCap)
            .WithMany(y => y.SanPham)
            .HasForeignKey(f => f.NCC_ID)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<HoaDonCT>()
            //.HasKey(i => new { i.MAHD, i.MASP });


            modelBuilder.Entity<HoaDonCT>()
            .HasOne(x => x.SanPham)
            .WithMany(y => y.HoaDonCT)
            .HasForeignKey(f => f.MASP)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HoaDonCT>()
            .HasOne(o => o.HoaDon)
            .WithMany(m => m.HoaDonCT)
            .HasForeignKey(f => f.MAHD)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HoaDon>()
            .HasOne(x => x.KhachHang)
            .WithMany(y => y.HoaDon)
            .HasForeignKey(f => f.MAKH_id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        }

            public DbSet<KhachHang> KhachHangs => Set<KhachHang>();
            public DbSet<HoaDon> HoaDons => Set<HoaDon>();
            public DbSet<HoaDonCT> HoaDonCTs => Set<HoaDonCT>();
            public DbSet<SanPham> SanPhams => Set<SanPham>();
            public DbSet<NhaCungCap> NhaCungCaps => Set<NhaCungCap>();
            public DbSet<Admin> Admins => Set<Admin>();

    
    }
}