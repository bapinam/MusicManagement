using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicManagement.Data;
using Volo.Abp.DependencyInjection;

namespace MusicManagement.EntityFrameworkCore
{
    public class EntityFrameworkCoreMusicManagementDbSchemaMigrator
        : IMusicManagementDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreMusicManagementDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the MusicManagementDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<MusicManagementDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
