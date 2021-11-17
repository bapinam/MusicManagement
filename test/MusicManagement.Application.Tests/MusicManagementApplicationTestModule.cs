using Volo.Abp.Modularity;

namespace MusicManagement
{
    [DependsOn(
        typeof(MusicManagementApplicationModule),
        typeof(MusicManagementDomainTestModule)
        )]
    public class MusicManagementApplicationTestModule : AbpModule
    {

    }
}