using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicManagement.MultiTenancy;
using MusicManagement.Singers;
using MusicManagement.SingerSongs;
using MusicManagement.Songs;

namespace MusicManagement.ConfigureFluentAPI
{
    public class SingerSongConfigure : IEntityTypeConfiguration<SingerSong>
    {
        public void Configure(EntityTypeBuilder<SingerSong> builder)
        {
            builder.ToTable(MultiTenancyConsts.NameDbTable + "SingerSongs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne<Singer>().WithMany().IsRequired();
            builder.HasOne<Song>().WithMany().IsRequired();
        }
    }
}