using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;

namespace MusicManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(MusicManagementDomainModule),
        typeof(AbpIdentityProEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule),
        typeof(LanguageManagementEntityFrameworkCoreModule),
        typeof(SaasEntityFrameworkCoreModule),
        typeof(TextTemplateManagementEntityFrameworkCoreModule),
        typeof(BlobStoringDatabaseEntityFrameworkCoreModule)
        )]
    public class MusicManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            MusicManagementEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MusicManagementDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also MusicManagementDbContextFactory for EF Core tooling. */
                options.UseMySQL();
            });
        }
    }
}
