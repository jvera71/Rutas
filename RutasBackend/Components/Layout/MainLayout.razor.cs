using System.Net.Http;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using RutasBackend.Services;

namespace RutasBackend.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        private bool sidebarExpanded = true;

        [Inject]
        protected SecurityService Security { get; set; }

        protected string SelectedCulture = CultureInfo.CurrentCulture.Name;

        protected IEnumerable<object> SupportedCultures = new[]
        {
            new { Name = "Español", Value = "es" },
            new { Name = "English", Value = "en" },
            new { Name = "Français", Value = "fr" },
            new { Name = "Català", Value = "ca" },
            new { Name = "Euskara", Value = "eu" },
            new { Name = "Galego", Value = "gl" }
        };

        protected void OnCultureChange(object value)
        {
            var culture = (string)value;
            var redirectUri = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
            NavigationManager.NavigateTo($"/Culture/SetCulture?culture={culture}&redirectUri={Uri.EscapeDataString("/" + redirectUri)}", forceLoad: true);
        }

        void SidebarToggleClick()
        {
            sidebarExpanded = !sidebarExpanded;
        }

        protected void ProfileMenuClick(RadzenProfileMenuItem args)
        {
            if (args.Value == "Logout")
            {
                Security.Logout();
            }
        }
    }
}
