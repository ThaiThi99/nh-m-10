using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoiThatStoreAPI.Models
{
    [Table("HoaDonCT")]
    public class HoaDonCT
    {
        [Key]
		public long? id { get; set; }

		[Required]
     
        public long? MAHD { get; set; }
        
        [Required]
        public long? MASP { get; set; }
            
        [Required]
        public int SL { get; set; }
        [Required]
        public decimal DONGIA { get; set; }
        public HoaDon? HoaDon { get; set; }
        public SanPham? SanPham { get; set; }

    }
}
