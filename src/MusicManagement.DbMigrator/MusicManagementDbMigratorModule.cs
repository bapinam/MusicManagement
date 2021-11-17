using MusicManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MusicManagement.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(MusicManagementEntityFrameworkCoreModule),
        typeof(MusicManagementApplicationContractsModule)
    )]
    public class MusicManagementDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}
