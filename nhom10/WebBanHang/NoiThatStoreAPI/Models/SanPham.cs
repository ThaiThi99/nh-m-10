using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoiThatStoreAPI.Models
{
    [Table("SanPham")]

    public class SanPham
    {
        [Key]
        public long? MASP { get; set; }
        
       
        public long? NCC_ID { get; set; }
        [Required]
        [MaxLength(200)]

        public string TENSP { get; set; } = null!;

        [Required]
        [MaxLength(100)]

        public string LOAI { get; set; } = null!;
        [Required]
        [MaxLength(100)]

        public string CHATLIEU { get; set; } = null!;
        [Required]
        public int TONKHO { get; set; }
		public double GiaBan { get; set; }
		[Required]
        [MaxLength(100)]

        public string HINHANH { get; set; } = null!;
		public string MoTa { get; set; } = null!;
		public ICollection<HoaDonCT>? HoaDonCT { get; set; }

        [ForeignKey("NCC_ID")]
        public NhaCungCap? NhaCungCap { get; set; }

    }
}
