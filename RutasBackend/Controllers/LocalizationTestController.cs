using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace RutasBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizationTestController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public LocalizationTestController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Hello = _localizer["Hello"].Value,
                Welcome = _localizer["Welcome"].Value,
                Culture = System.Globalization.CultureInfo.CurrentCulture.Name
            });
        }
    }
}
