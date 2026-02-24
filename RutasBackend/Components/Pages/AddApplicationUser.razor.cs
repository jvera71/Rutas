using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RutasBackend.Services;
using RutasBackend.Data;
using RutasBackend.Models.Bd;
using Microsoft.EntityFrameworkCore;

namespace RutasBackend.Components.Pages
{
    public partial class AddApplicationUser
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

        [Inject]
        protected BdContext DbContext { get; set; }

        protected IEnumerable<RutasBackend.Models.ApplicationRole> roles;
        protected RutasBackend.Models.ApplicationUser user;
        protected IEnumerable<string> userRoles = Enumerable.Empty<string>();
        protected IEnumerable<OfficialEntity> officialEntities;
        protected Guid? selectedOfficialEntityId;
        protected string error;
        protected bool errorVisible;

        [Inject]
        protected SecurityService Security { get; set; }

        protected override async Task OnInitializedAsync()
        {
            user = new RutasBackend.Models.ApplicationUser();

            roles = await Security.GetRoles();
            officialEntities = await DbContext.OfficialEntities.ToListAsync();
        }

        protected bool IsOfficialEntityRoleSelected()
        {
            if (roles == null || userRoles == null) return false;
            
            var selectedRoles = roles.Where(r => userRoles.Contains(r.Id));
            return selectedRoles.Any(r => r.Name == Constants.RoleNames.OfficialEntityAdmin || r.Name == Constants.RoleNames.OfficialEntityUser);
        }

        protected async Task FormSubmit(RutasBackend.Models.ApplicationUser user)
        {
            try
            {
                user.Roles = roles.Where(role => userRoles.Contains(role.Id)).ToList();
                var newUser = await Security.CreateUser(user);

                if (newUser != null && selectedOfficialEntityId.HasValue && IsOfficialEntityRoleSelected())
                {
                    var officialEntityUser = new OfficialEntityUser
                    {
                        Id = Guid.NewGuid(),
                        OfficialEntityId = selectedOfficialEntityId.Value,
                        ApplicationUserId = newUser.Id
                    };
                    DbContext.OfficialEntityUsers.Add(officialEntityUser);
                    await DbContext.SaveChangesAsync();
                }

                DialogService.Close(null);
            }
            catch (Exception ex)
            {
                errorVisible = true;
                error = ex.Message;
            }
        }

        protected async Task CancelClick()
        {
            DialogService.Close(null);
        }
    }
}