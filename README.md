# Clym CMP for nopCommerce

Inject the [Clym](https://clym.io) Widget into your nopCommerce 4.70 store's `<head>` using the built-in widget zone system.

## Requirements

- nopCommerce 4.70
- .NET 8

## Development setup

This plugin is developed inside the nopCommerce source tree. Place the plugin folder at:

```
src/Plugins/Nop.Plugin.Widgets.ClymCmp/
```

Then add a reference to the project in your nopCommerce solution and build.

## Installation (store owners)

1. Download the plugin ZIP from the [nopCommerce Marketplace](https://www.nopcommerce.com/en/clym-cmp)
2. In your admin panel go to **Configuration → Local plugins → Upload plugin or theme**
3. Upload the ZIP and click **Install**
4. Go to **Configuration → Widgets → Clym CMP → Configure**
5. Enter your **Widget ID** — log in at [auth.clym.io](https://auth.clym.io). No account? Register at [register.clym.io](https://register.clym.io)
6. Save

## How it works

The plugin registers itself in the `head_html_tag` widget zone — nopCommerce's built-in zone that renders inside `<head>`. It outputs:

```html
<script src='https://config.clym-widget.net/v2/YOUR-WIDGET-ID.js'></script>
<script src='https://widget-next.clym-sdk.net/v2/stub.js' data-property='YOUR-WIDGET-ID'></script>
```

Scripts are synchronous (no `defer` or `async`).

## Documentation

https://knowledge.clym.io/en/article/clym-plugins-jeagzs/

## Support

https://knowledge.clym.io/en/
