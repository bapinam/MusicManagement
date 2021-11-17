using MusicManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MusicManagement
{
    [DependsOn(
        typeof(MusicManagementEntityFrameworkCoreTestModule)
        )]
    public class MusicManagementDomainTestModule : AbpModule
    {

    }
}