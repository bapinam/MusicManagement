using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace MusicManagement.Albums
{
    public class AlbumAppService : MusicManagementAppService, IAlbumAppService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly AlbumManager _albumManager;
        private readonly IdentityUserManager _currentUser;

        public AlbumAppService(
            IAlbumRepository abumRepository,
            AlbumManager albumManager,
            IdentityUserManager currentUser)
        {
            _albumRepository = abumRepository;
            _albumManager = albumManager;
            _currentUser = currentUser;
        }

        public async Task<AlbumDto> CreateAsync(CreateAlbumDto input)
        {
            var album = await _albumManager.CreateAsync(
                                                     input.Creator,
                                                     input.Name,
                                                     input.Description
                                                   );

            await _albumRepository.InsertAsync(album);

            var result = ObjectMapper.Map<Album, AlbumDto>(album);

            var user = await _currentUser.FindByIdAsync(album.CreatorId.ToString());
            result.Creator = user.UserName;
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            var album = await _albumRepository.GetAsync(id);

            if (album == null)
            {
                throw new AlbumIdAlreadyExistsException(id.ToString());
            }

            await _albumRepository.DeleteAsync(id);
        }

        public async Task<AlbumDto> GetAsync(Guid id)
        {
            var album = await _albumRepository.GetAsync(id);
            return ObjectMapper.Map<Album, AlbumDto>(album);
        }

        public async Task<PagedResultDto<AlbumDto>> GetListAsync(GetAlbumListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Album.Name);
            }

            var albums = await _albumRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var query = (from album in albums
                         join user in _currentUser.Users
                              on album.CreatorId equals user.Id
                         select new
                         {
                             album.Name,
                             album.Id,
                             album.Description,
                             album.CreationTime,
                             user.UserName
                         }).ToList();

            List<AlbumDto> objectList = query.Select(o =>
                        new AlbumDto
                        {
                            Id = o.Id,
                            Name = o.Name,
                            Description = o.Description,
                            CreationTime = o.CreationTime,
                            Creator = o.UserName
                        }).ToList();

            var totalCount = input.Filter == null
                ? objectList.Count()
                : objectList.Count(
                    album => album.Name.Contains(input.Filter));

            var reuslt = new PagedResultDto<AlbumDto>(totalCount, objectList);

            return reuslt;
        }

        public async Task UpdateAsync(Guid id, UpdateAlbumDto input)
        {
            var album = await _albumRepository.GetAsync(id);

            if (album == null)
            {
                throw new AlbumIdAlreadyExistsException(id.ToString());
            }

            if (album.Name != input.Name)
            {
                await _albumManager.ChangeNameAsync(album, input.Name);
            }

            album.Description = input.Description;

            await _albumRepository.UpdateAsync(album);
        }
    }
}