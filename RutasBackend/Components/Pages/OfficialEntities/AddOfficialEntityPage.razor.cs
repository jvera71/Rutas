using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Radzen;
using RutasBackend.Data;
using RutasBackend.Models.Bd;

namespace RutasBackend.Components.Pages.OfficialEntities
{
    public partial class AddOfficialEntityPage : ComponentBase
    {
        [Inject] protected BdContext DbContext { get; set; }
        [Inject] protected DialogService DialogService { get; set; }
        [Inject] protected IStringLocalizer<SharedResource> L { get; set; }

        protected OfficialEntity model = new OfficialEntity();

        protected async Task HandleSubmit(OfficialEntity entity)
        {
            DbContext.OfficialEntities.Add(entity);
            await DbContext.SaveChangesAsync();
            DialogService.Close(true);
        }

        protected void HandleCancel()
        {
            DialogService.Close(false);
        }
    }
}
