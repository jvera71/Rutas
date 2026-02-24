using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Radzen;
using RutasBackend.Data;
using RutasBackend.Models.Bd;

namespace RutasBackend.Components.Pages.OfficialEntities
{
    public partial class OfficialEntitiesPage : ComponentBase
    {
        [Inject] protected BdContext DbContext { get; set; }
        [Inject] protected DialogService DialogService { get; set; }
        [Inject] protected IStringLocalizer<SharedResource> L { get; set; }

        protected IEnumerable<OfficialEntity> entities;

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            entities = await DbContext.OfficialEntities.ToListAsync();
        }

        protected async Task AddClick()
        {
            bool? result = await DialogService.OpenAsync<AddOfficialEntityPage>(L["Add_Official_Entity"] ?? "Add Official Entity");
            if (result == true)
            {
                await LoadDataAsync();
                StateHasChanged();
            }
        }

        protected async Task EditClick(OfficialEntity entity)
        {
            bool? result = await DialogService.OpenAsync<EditOfficialEntityPage>(L["Edit_Official_Entity"] ?? "Edit Official Entity", 
                new Dictionary<string, object> { { "Id", entity.Id } });
            if (result == true)
            {
                await LoadDataAsync();
                StateHasChanged();
            }
        }

        protected async Task DeleteClick(OfficialEntity entity)
        {
            if (await DialogService.Confirm(L["Delete_Official_Entity_Confirm"] ?? "Are you sure you want to delete this entity?") == true)
            {
                DbContext.OfficialEntities.Remove(entity);
                await DbContext.SaveChangesAsync();
                await LoadDataAsync();
                StateHasChanged();
            }
        }
    }
}
