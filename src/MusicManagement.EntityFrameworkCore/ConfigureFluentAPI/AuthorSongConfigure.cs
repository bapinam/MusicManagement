using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicManagement.Authors;
using MusicManagement.AuthorSongs;
using MusicManagement.MultiTenancy;
using MusicManagement.Songs;

namespace MusicManagement.ConfigureFluentAPI
{
    public class AuthorSongConfigure : IEntityTypeConfiguration<AuthorSong>
    {
        public void Configure(EntityTypeBuilder<AuthorSong> builder)
        {
            builder.ToTable(MultiTenancyConsts.NameDbTable + "AuthorSongs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne<Author>().WithMany().IsRequired();
            builder.HasOne<Song>().WithMany().IsRequired();
        }
    }
}