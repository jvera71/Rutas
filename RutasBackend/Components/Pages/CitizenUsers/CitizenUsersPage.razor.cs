using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Radzen;
using RutasBackend.Data;
using RutasBackend.Models.Bd;
using RutasBackend.Services;

namespace RutasBackend.Components.Pages.CitizenUsers
{
    public partial class CitizenUsersPage : ComponentBase
    {
        [Inject] protected BdContext DbContext { get; set; }
        [Inject] protected DialogService DialogService { get; set; }
        [Inject] protected IStringLocalizer<SharedResource> L { get; set; }
        [Inject] protected SecurityService Security { get; set; }

        protected IEnumerable<CitizenUser> users;

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var entityUser = await DbContext.OfficialEntityUsers
                .FirstOrDefaultAsync(u => u.ApplicationUserId == Security.User.Id);

            if (entityUser != null)
            {
                users = await DbContext.CitizenUsers
                    .Where(c => c.OfficialEntityId == entityUser.OfficialEntityId)
                    .ToListAsync();
            }
            else
            {
                users = new List<CitizenUser>();
            }
        }

        protected async Task AddClick()
        {
            await DialogService.OpenAsync<AddCitizenUserPage>(L["Add_Citizen_User"] ?? "Add Citizen User");
            await LoadDataAsync();
            StateHasChanged();
        }

        protected async Task EditClick(CitizenUser user)
        {
            await DialogService.OpenAsync<EditCitizenUserPage>(L["Edit_Citizen_User"] ?? "Edit Citizen User", new Dictionary<string, object> { { "Id", user.Id } });
            await LoadDataAsync();
            StateHasChanged();
        }

        protected async Task DeleteClick(CitizenUser user)
        {
            if (await DialogService.Confirm(L["Delete_Citizen_Confirm"] ?? "Are you sure you want to delete this user?") == true)
            {
                DbContext.CitizenUsers.Remove(user);
                await DbContext.SaveChangesAsync();
                await LoadDataAsync();
                StateHasChanged();
            }
        }
    }
}
