using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Radzen;
using RutasBackend.Data;
using RutasBackend.Models.Bd;

namespace RutasBackend.Components.Pages.OfficialEntities
{
    public partial class EditOfficialEntityPage : ComponentBase
    {
        [Inject] protected BdContext DbContext { get; set; }
        [Inject] protected DialogService DialogService { get; set; }
        [Inject] protected IStringLocalizer<SharedResource> L { get; set; }

        [Parameter] public Guid Id { get; set; }

        protected OfficialEntity model;

        protected override async Task OnInitializedAsync()
        {
            model = await DbContext.OfficialEntities.FindAsync(Id);
        }

        protected async Task HandleSubmit(OfficialEntity entity)
        {
            DbContext.OfficialEntities.Update(entity);
            await DbContext.SaveChangesAsync();
            DialogService.Close(true);
        }

        protected void HandleCancel()
        {
            DialogService.Close(false);
        }
    }
}
