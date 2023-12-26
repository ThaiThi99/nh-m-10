using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace NoiThatStoreAPI.DTO
{
    public class HoaDonDTO
    {
        public long? MAHD { get; set; }

        [Required]
        public long? MAKH_id { get; set; } = null!;
        [Required]
        public decimal GIABAN { get; set; }

        [Required]
        public DateTime NGAYHD { get; set; }
        [Required]
        public string LOAIHD { get; set; } = null!;
    }
}
