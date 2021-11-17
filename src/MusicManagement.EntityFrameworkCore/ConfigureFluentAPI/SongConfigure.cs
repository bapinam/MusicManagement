using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicManagement.Albums;
using MusicManagement.Categories;
using MusicManagement.MultiTenancy;
using MusicManagement.Songs;
using Volo.Abp.Identity;

namespace MusicManagement.ConfigureFluentAPI
{
    public class SongConfigure : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable(MultiTenancyConsts.NameDbTable + "Songs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            // liên kết khóa ngoại
            builder.HasOne<Category>().WithMany().IsRequired();
            builder.HasOne<Album>().WithMany().IsRequired();
            builder.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.CreatorId).IsRequired();
        }
    }
}