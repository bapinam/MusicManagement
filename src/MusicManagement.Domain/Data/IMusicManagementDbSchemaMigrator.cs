using System.Threading.Tasks;

namespace MusicManagement.Data
{
    public interface IMusicManagementDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}