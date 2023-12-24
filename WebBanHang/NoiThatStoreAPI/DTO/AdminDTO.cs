using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace NoiThatStoreAPI.DTO
{
    public class AdminDTO
    {
		public long? ADMINID { get; set; }
		[Required]
        public string? TEN_TK { get; set; } = null!;
		[Required]
        public string? pass { get; set; }
    }
}