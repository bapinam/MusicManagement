using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MusicManagement.SingerSongs
{
    public interface ISingerSongRepository : IRepository<SingerSong, Guid>
    {
    }
}