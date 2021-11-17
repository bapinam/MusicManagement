using MusicManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MusicManagement.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class MusicManagementController : AbpController
    {
        protected MusicManagementController()
        {
            LocalizationResource = typeof(MusicManagementResource);
        }
    }
}