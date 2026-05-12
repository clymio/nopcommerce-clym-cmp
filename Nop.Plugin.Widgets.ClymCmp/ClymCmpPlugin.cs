using Nop.Core;
using Nop.Plugin.Widgets.ClymCmp.Components;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.ClymCmp;

public class ClymCmpPlugin : BasePlugin, IWidgetPlugin
{
    private readonly ILocalizationService _localizationService;
    private readonly ISettingService _settingService;
    private readonly IWebHelper _webHelper;

    public ClymCmpPlugin(
        ILocalizationService localizationService,
        ISettingService settingService,
        IWebHelper webHelper)
    {
        _localizationService = localizationService;
        _settingService = settingService;
        _webHelper = webHelper;
    }

    public bool HideInWidgetList => false;

    public Type GetWidgetViewComponent(string widgetZone) => typeof(WidgetsClymCmpViewComponent);

    public Task<IList<string>> GetWidgetZonesAsync()
    {
        return Task.FromResult<IList<string>>(new List<string>
        {
            PublicWidgetZones.HeadHtmlTag
        });
    }

    public override string GetConfigurationPageUrl()
    {
        return $"{_webHelper.GetStoreLocation()}Admin/ClymCmp/Configure";
    }

    public override async Task InstallAsync()
    {
        await _settingService.SaveSettingAsync(new ClymCmpSettings());
        await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {
            ["Plugins.Widgets.ClymCmp.WidgetId"] = "Widget ID",
            ["Plugins.Widgets.ClymCmp.WidgetId.Hint"] = "Enter your Clym Widget ID (e.g. abce86a6fc7a473d82f7cca4qrbh0oln). Log in at auth.clym.io or register at register.clym.io. Setup guide: https://knowledge.clym.io/en/article/clym-plugins-jeagzs/",
        });
        await base.InstallAsync();
    }

    public override async Task UninstallAsync()
    {
        await _settingService.DeleteSettingAsync<ClymCmpSettings>();
        await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.ClymCmp");
        await base.UninstallAsync();
    }
}
