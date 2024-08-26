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
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<DispatchRecordsService>();
            builder.Services.AddTransient<DispatchViewModel>();
            builder.Services.AddTransient<DispatchView>();

            builder.Services.AddSingleton<TrucksService>();
            builder.Services.AddSingleton<DispatchTrucksViewModel>();
            builder.Services.AddSingleton<DispatchTrucksView>();

            builder.Services.AddSingleton<EmployeeService>();
            builder.Services.AddSingleton<EmployeeViewModel>();
            builder.Services.AddSingleton<EmployeeView>();

            builder.Services.AddSingleton<DispatchStatusService>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<HomeView>();

            return builder.Build();
        }
    }
}
