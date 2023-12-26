using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoiThatStoreAPI.Models
{
    [Table("NhaCungCap")]

    public class NhaCungCap
    {
        [Key]
       
        public long? NCC_ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string TEN { get; set; } = null!;
        [Required]
        [MaxLength(200)]

        public string DIACHI { get; set; } = null!;

        [Required]
       

        public int SDT { get; set; }

        [Required]
        [MaxLength(100)]

        public string EMAIL { get; set; } = null!;

        public ICollection<SanPham>? SanPham { get; set; }
    }
}
