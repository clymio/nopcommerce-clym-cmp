using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.ClymCmp.Components;

public class WidgetsClymCmpViewComponent : NopViewComponent
{
    private readonly ISettingService _settingService;
    private readonly IStoreContext _storeContext;

    public WidgetsClymCmpViewComponent(ISettingService settingService, IStoreContext storeContext)
    {
        _settingService = settingService;
        _storeContext = storeContext;
    }

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object? additionalData)
    {
        var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
        var settings = await _settingService.LoadSettingAsync<ClymCmpSettings>(storeScope);

        if (string.IsNullOrWhiteSpace(settings.WidgetId))
            return Content(string.Empty);

        return View("~/Plugins/Widgets.ClymCmp/Views/PublicInfo.cshtml", settings.WidgetId);
    }
}
