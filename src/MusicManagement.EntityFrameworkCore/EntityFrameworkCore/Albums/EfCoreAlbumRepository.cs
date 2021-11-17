using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicManagement.Albums;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MusicManagement.EntityFrameworkCore.Albums
{
    public class EfCoreAlbumRepository
         : EfCoreRepository<MusicManagementDbContext, Album, Guid>,
             IAlbumRepository
    {
        public EfCoreAlbumRepository(
            IDbContextProvider<MusicManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Album> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(album => album.Name == name);
        }

        public async Task<List<Album>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    album => album.Name.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}