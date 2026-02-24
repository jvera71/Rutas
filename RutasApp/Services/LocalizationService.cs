using System.Globalization;

namespace RutasApp.Services
{
    public class LocalizationService
    {
        public void SetCulture(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            
            // For some platforms or older versions, you might need:
            // Thread.CurrentThread.CurrentCulture = culture;
            // Thread.CurrentThread.CurrentUICulture = culture;
        }

        public string CurrentCulture => CultureInfo.CurrentCulture.Name;
    }
}
