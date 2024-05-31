using LoudPhone.Interfaces;
using LoudPhone.Services;
using LoudPhone.ViewModels;
using Microsoft.Extensions.Logging;

namespace LoudPhone
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

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<IDefaultSettings, DefaultSettings>();
            builder.Services.AddSingleton<IAudioManagerService, AudioManagerService>();
            builder.Services.AddSingleton<IOpenDontDisturbService, OpenDontDisturbService>();
            builder.Services.AddSingleton<ISilentModeService, MainActivity>();
            builder.Services.AddTransient<ConfigsViewModel>();

            return builder.Build();
        }

    }
}
