using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using RutasBackend.Data;

namespace RutasBackend
{
    public partial class BdService
    {
        BdContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly BdContext context;
        private readonly NavigationManager navigationManager;

        public BdService(BdContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public void ApplyQuery<T>(ref IQueryable<T> items, Query query = null)
        {
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }
        }


        public async Task ExportOfficialEntitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/bd/officialentities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/bd/officialentities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOfficialEntitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/bd/officialentities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/bd/officialentities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOfficialEntitiesRead(ref IQueryable<RutasBackend.Models.Bd.OfficialEntity> items);

        public async Task<IQueryable<RutasBackend.Models.Bd.OfficialEntity>> GetOfficialEntities(Query query = null)
        {
            var items = Context.OfficialEntities.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnOfficialEntitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOfficialEntityGet(RutasBackend.Models.Bd.OfficialEntity item);
        partial void OnGetOfficialEntityById(ref IQueryable<RutasBackend.Models.Bd.OfficialEntity> items);


        public async Task<RutasBackend.Models.Bd.OfficialEntity> GetOfficialEntityById(Guid id)
        {
            var items = Context.OfficialEntities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetOfficialEntityById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnOfficialEntityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnOfficialEntityCreated(RutasBackend.Models.Bd.OfficialEntity item);
        partial void OnAfterOfficialEntityCreated(RutasBackend.Models.Bd.OfficialEntity item);

        public async Task<RutasBackend.Models.Bd.OfficialEntity> CreateOfficialEntity(RutasBackend.Models.Bd.OfficialEntity officialentity)
        {
            OnOfficialEntityCreated(officialentity);

            var existingItem = Context.OfficialEntities
                              .Where(i => i.Id == officialentity.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.OfficialEntities.Add(officialentity);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(officialentity).State = EntityState.Detached;
                throw;
            }

            OnAfterOfficialEntityCreated(officialentity);

            return officialentity;
        }

        public async Task<RutasBackend.Models.Bd.OfficialEntity> CancelOfficialEntityChanges(RutasBackend.Models.Bd.OfficialEntity item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOfficialEntityUpdated(RutasBackend.Models.Bd.OfficialEntity item);
        partial void OnAfterOfficialEntityUpdated(RutasBackend.Models.Bd.OfficialEntity item);

        public async Task<RutasBackend.Models.Bd.OfficialEntity> UpdateOfficialEntity(Guid id, RutasBackend.Models.Bd.OfficialEntity officialentity)
        {
            OnOfficialEntityUpdated(officialentity);

            var itemToUpdate = Context.OfficialEntities
                              .Where(i => i.Id == officialentity.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(officialentity);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterOfficialEntityUpdated(officialentity);

            return officialentity;
        }

        partial void OnOfficialEntityDeleted(RutasBackend.Models.Bd.OfficialEntity item);
        partial void OnAfterOfficialEntityDeleted(RutasBackend.Models.Bd.OfficialEntity item);

        public async Task<RutasBackend.Models.Bd.OfficialEntity> DeleteOfficialEntity(Guid id)
        {
            var itemToDelete = Context.OfficialEntities
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOfficialEntityDeleted(itemToDelete);


            Context.OfficialEntities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOfficialEntityDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}