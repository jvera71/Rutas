using System;
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
    public partial class EditCitizenUserPage : ComponentBase
    {
        [Inject] protected BdContext DbContext { get; set; }
        [Inject] protected DialogService DialogService { get; set; }
        [Inject] protected IStringLocalizer<SharedResource> L { get; set; }
        [Inject] protected SecurityService Security { get; set; }

        [Parameter] public Guid Id { get; set; }

        protected CitizenUser model;

        protected override async Task OnInitializedAsync()
        {
            var entityUser = await DbContext.OfficialEntityUsers
                .FirstOrDefaultAsync(u => u.ApplicationUserId == Security.User.Id);

            if (entityUser != null)
            {
                model = await DbContext.CitizenUsers.FirstOrDefaultAsync(c => c.Id == Id && c.OfficialEntityId == entityUser.OfficialEntityId);
            }

            if (model == null)
            {
                DialogService.Close(false);
            }
        }

        protected async Task HandleSubmit(CitizenUser user)
        {
            DbContext.CitizenUsers.Update(user);
            await DbContext.SaveChangesAsync();
            DialogService.Close(true);
        }

        protected void HandleCancel()
        {
            DialogService.Close(false);
        }
    }
}
