using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicManagement.Categories;
using MusicManagement.MultiTenancy;
using Volo.Abp.Identity;

namespace MusicManagement.ConfigureFluentAPI
{
    public class CategoryConfigure : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(MultiTenancyConsts.NameDbTable + "Categorys");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(CategoryConsts.MaxNameLength).IsRequired();

            builder.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.CreatorId).IsRequired();
        }
    }
}