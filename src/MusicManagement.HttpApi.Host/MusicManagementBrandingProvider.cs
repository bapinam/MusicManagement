using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MusicManagement
{
    [Dependency(ReplaceServices = true)]
    public class MusicManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "MusicManagement";
    }
}
