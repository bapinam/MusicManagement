using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicManagement.Albums;
using MusicManagement.MultiTenancy;
using Volo.Abp.Identity;

namespace MusicManagement.ConfigureFluentAPI
{
    public class AlbumConfigure : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable(MultiTenancyConsts.NameDbTable + "Albums");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(AlbumConsts.MaxNameLength).IsRequired();

            builder.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.CreatorId).IsRequired();
        }
    }
}