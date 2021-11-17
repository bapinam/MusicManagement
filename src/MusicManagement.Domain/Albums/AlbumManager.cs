using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace MusicManagement.Albums
{
    public class AlbumManager : DomainService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumManager(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<Album> CreateAsync(
            [NotNull] Guid creatorId,
            [NotNull] string name,
            [CanBeNull] string description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _albumRepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new AlbumNameAlreadyExistsException(name);
            }

            return new Album(
                GuidGenerator.Create(),
                creatorId,
                name,
                description
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Album album,
            [NotNull] string newName)
        {
            Check.NotNull(album, nameof(album));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingAuthor = await _albumRepository.FindByNameAsync(newName);
            if (existingAuthor != null && existingAuthor.Id != album.Id)
            {
                throw new AlbumNameAlreadyExistsException(newName);
            }

            album.ChangeName(newName);
        }
    }
}