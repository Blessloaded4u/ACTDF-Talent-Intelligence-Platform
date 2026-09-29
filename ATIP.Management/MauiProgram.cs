using ATIP.Management.Services;
using Microsoft.Extensions.Logging;

namespace ATIP.Management
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7092/")
            });

            builder.Services.AddSingleton<IAtipApiClient, AtipApiClient>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
