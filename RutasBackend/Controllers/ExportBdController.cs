using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using RutasBackend.Data;

namespace RutasBackend.Controllers
{
    public partial class ExportBdController : ExportController
    {
        private readonly BdContext context;
        private readonly BdService service;

        public ExportBdController(BdContext context, BdService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Bd/officialentities/csv")]
        [HttpGet("/export/Bd/officialentities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOfficialEntitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOfficialEntities(), Request.Query, false), fileName);
        }

        [HttpGet("/export/Bd/officialentities/excel")]
        [HttpGet("/export/Bd/officialentities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOfficialEntitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOfficialEntities(), Request.Query, false), fileName);
        }
    }
}
