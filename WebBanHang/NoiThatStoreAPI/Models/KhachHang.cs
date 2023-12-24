using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoiThatStoreAPI.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
    
        public long? MAKH_id { get; set; }
        [Required]
        [MaxLength(100)]
        public string TEN { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string HOLOT { get; set; } = null!;

        [Required]
        [MaxLength(100)]

        public string EMAIL { get; set; } = null!;
        [Required]
        
        public int SDT { get; set; }

        [Required]
        public bool GIOITINH { get; set; }
        public ICollection<HoaDon>? HoaDon { get; set; }
    }
}
