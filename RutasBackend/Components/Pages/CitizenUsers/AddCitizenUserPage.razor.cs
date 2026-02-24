using System;
using System.Linq;
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
    public partial class AddCitizenUserPage : ComponentBase
    {
        [Inject] protected BdContext DbContext { get; set; }
        [Inject] protected DialogService DialogService { get; set; }
        [Inject] protected IStringLocalizer<SharedResource> L { get; set; }
        [Inject] protected SecurityService Security { get; set; }

        protected CitizenUser model = new CitizenUser();

        protected override async Task OnInitializedAsync()
        {
            var entityUser = await DbContext.OfficialEntityUsers
                .FirstOrDefaultAsync(u => u.ApplicationUserId == Security.User.Id);

            model.Code = await GenerateUniqueCodeAsync();
            model.IsActive = true;
            model.CreatedAt = DateTime.UtcNow;
            model.Id = Guid.NewGuid();
            if (entityUser != null)
            {
                model.OfficialEntityId = entityUser.OfficialEntityId;
            }
        }

        private async Task<string> GenerateUniqueCodeAsync()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string code;
            do
            {
                code = new string(Enumerable.Repeat(chars, 3).Select(s => s[random.Next(s.Length)]).ToArray()) + "-" +
                       new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
            } while (await DbContext.CitizenUsers.AnyAsync(c => c.Code == code));
            
            return code;
        }

        protected async Task HandleSubmit(CitizenUser user)
        {
            DbContext.CitizenUsers.Add(user);
            await DbContext.SaveChangesAsync();
            DialogService.Close(true);
        }

        protected void HandleCancel()
        {
            DialogService.Close(false);
        }
    }
}
