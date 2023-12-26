using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoiThatStoreAPI.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
		public long? ADMINID { get; set; }
		[Required]
		[MaxLength(100)]

        public string TEN_TK { get; set; } = null!;
        [Required]
        [MaxLength(100)]

        public string PASS { get; set; } = null!;

		public class YourDbContext : DbContext
		{
			public DbSet<Admin> Admins { get; set; }

			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				modelBuilder.Entity<Admin>()
					.HasIndex(a => a.TEN_TK)
					.IsUnique();
			}
		}
	}
}
