using System;
using Volo.Abp.Domain.Repositories;

namespace MusicManagement.AuthorSongs
{
    public interface IAuthorSongRepository : IRepository<AuthorSong, Guid>
    {
    }
}