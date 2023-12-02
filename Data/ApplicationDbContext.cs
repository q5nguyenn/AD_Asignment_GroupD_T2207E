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
					.ToTable("PhotoTags");    //Định nghĩa tên bảng trong CSDL do do mình đặt tên Model ở đây với tên bảng trong CSDL không trùng khớp nên khi chạy nó sẽ báo lỗi Invalid Object Name...     
			//Quan he Many-to-Many
			builder.Entity<PhotoTag>()
			.HasKey(pt => new { pt.TagId, pt.PhotoId });

			builder.Entity<PhotoTag>()
					.HasOne(pt => pt.Photo)
					.WithMany(p => p.PhotoTags)
					.HasForeignKey(pt => pt.PhotoId);

			builder.Entity<PhotoTag>()
					.HasOne(pt => pt.Tag)
					.WithMany(t => t.PhotoTags)
					.HasForeignKey(pt => pt.TagId);
		}

        public DbSet<AD_Asignment_GroupD_T2207E.Models.Photo> Photos { get; set; }
        public DbSet<AD_Asignment_GroupD_T2207E.Models.Tag> Tags { get; set; }
		public DbSet<AD_Asignment_GroupD_T2207E.Models.PhotoTag> PhotoTag { get; set; }
	}
}