using AD_Asignment_GroupD_T2207E.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AD_Asignment_GroupD_T2207E.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


			builder.Entity<PhotoTag>()
					.HasKey(x =>new { x.PhotoId, x.TagId });
		}

        public DbSet<AD_Asignment_GroupD_T2207E.Models.Photo> Photos { get; set; }
        public DbSet<AD_Asignment_GroupD_T2207E.Models.Tag> Tags { get; set; }
		public DbSet<AD_Asignment_GroupD_T2207E.Models.PhotoTag> PhotoTags { get; set; }
	}
}