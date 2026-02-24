using Microsoft.Extensions.Logging;

namespace RutasApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddLocalization();
            builder.Services.AddSingleton<RutasApp.Services.LocalizationService>();
            builder.Services.AddSingleton<RutasApp.Services.SignalRService>(sp => 
                new RutasApp.Services.SignalRService("http://localhost:5000/apphub")); // Update with actual backend URL

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
