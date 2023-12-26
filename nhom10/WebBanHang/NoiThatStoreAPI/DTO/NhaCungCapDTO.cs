using System.ComponentModel.DataAnnotations;

namespace NoiThatStoreAPI.DTO
{
    public class NhaCungCapDTO
    {
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
    }
}
