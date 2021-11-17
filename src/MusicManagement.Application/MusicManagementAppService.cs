using MusicManagement.Localization;
using Volo.Abp.Application.Services;

namespace MusicManagement
{
    /* Inherit your application services from this class.
     */
    public abstract class MusicManagementAppService : ApplicationService
    {
        protected MusicManagementAppService()
        {
            LocalizationResource = typeof(MusicManagementResource);
        }
    }
}
