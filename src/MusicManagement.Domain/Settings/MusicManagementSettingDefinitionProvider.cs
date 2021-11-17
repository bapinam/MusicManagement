using Volo.Abp.Settings;

namespace MusicManagement.Settings
{
    public class MusicManagementSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(MusicManagementSettings.MySetting1));
        }
    }
}
