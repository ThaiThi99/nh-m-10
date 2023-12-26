using System.ComponentModel.DataAnnotations;

namespace NoiThatStoreAPI.DTO
{
    public class SanPhamDTO
    {
        public long? MASP { get; set; }

        [Required]
        public long? NCC_ID { get; set; } = null!;
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
        [Required]
        

		public double GiaBan { get; set; }
		[Required]
		[MaxLength(100)]

		public string HINHANH { get; set; } = null!;
		public string MoTa { get; set; } = null!;
	}
}
