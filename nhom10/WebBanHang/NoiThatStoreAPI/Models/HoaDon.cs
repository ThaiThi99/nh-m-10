using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoiThatStoreAPI.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public long? MAHD { get; set; }
       
        [Required]
        public long? MAKH_id { get; set; }
        [Required]
        public decimal GIABAN { get; set; }

        [Required]
        public DateTime NGAYHD { get; set; }
        [Required]
        public string LOAIHD { get; set; } = null!;

        public ICollection<HoaDonCT>? HoaDonCT { get; set; }
        //public HoaDonCT? HoaDonCT { get; set; }

        public KhachHang? KhachHang { get; set; }
    }
}
