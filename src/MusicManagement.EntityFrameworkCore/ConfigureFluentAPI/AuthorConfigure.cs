using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicManagement.Authors;
using MusicManagement.MultiTenancy;
using Volo.Abp.Identity;

namespace MusicManagement.ConfigureFluentAPI
{
    public class AuthorConfigure : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(MultiTenancyConsts.NameDbTable + "Authors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(AuthorConsts.MaxNameLength).IsRequired();

            builder.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.CreatorId).IsRequired();
        }
    }
}