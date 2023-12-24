using System.ComponentModel.DataAnnotations;

namespace NoiThatStoreAPI.DTO
{
    public class HoaDonCTDTO
    {

		public long? id { get; set; }
		[Required]
		public long? MAHD { get; set; }
        [Required]
        public long? MASP { get; set; }

        [Required]
        public int SL { get; set; }
        [Required]
        public decimal DONGIA { get; set; }
    }
}
