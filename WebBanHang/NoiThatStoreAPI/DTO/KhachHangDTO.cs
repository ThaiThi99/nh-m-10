using System.ComponentModel.DataAnnotations;

namespace NoiThatStoreAPI.DTO
{
    public class KhachHangDTO
    {
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
    }
}
