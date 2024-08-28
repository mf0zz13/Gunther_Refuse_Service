using Microsoft.Extensions.Logging;

namespace GuntherRefuse
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers((handlers) => {
#if IOS
                handlers.AddHandler(typeof(Shell), typeof(CustomShellRenderer));  
#endif
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<DispatchService>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<HomeView>();

            builder.Services.AddSingleton<TrucksService>();
            builder.Services.AddSingleton<DispatchTrucksViewModel>();
            builder.Services.AddSingleton<DispatchTrucksView>();

            builder.Services.AddTransient<DispatchViewModel>();
            builder.Services.AddTransient<DispatchView>();

            builder.Services.AddSingleton<ManageEmployeesView>();

            return builder.Build();
        }
    }
}
