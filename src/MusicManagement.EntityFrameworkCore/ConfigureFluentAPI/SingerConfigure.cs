using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicManagement.MultiTenancy;
using MusicManagement.Singers;
using Volo.Abp.Identity;

namespace MusicManagement.ConfigureFluentAPI
{
    public class SingerConfigure : IEntityTypeConfiguration<Singer>
    {
        public void Configure(EntityTypeBuilder<Singer> builder)
        {
            builder.ToTable(MultiTenancyConsts.NameDbTable + "Singers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.CreatorId).IsRequired();
        }
    }
}