using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MusicManagement.Data
{
    /* This is used if database provider does't define
     * IMusicManagementDbSchemaMigrator implementation.
     */
    public class NullMusicManagementDbSchemaMigrator : IMusicManagementDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}