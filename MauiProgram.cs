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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<DispatchService>();
            builder.Services.AddTransient<DispatchViewModel>();
            builder.Services.AddTransient<DispatchView>();

            builder.Services.AddSingleton<DispatcherService>();
            builder.Services.AddSingleton<DispatcherViewModel>();
            builder.Services.AddSingleton<DispatcherView>();

            builder.Services.AddSingleton<EmployeeService>();
            builder.Services.AddSingleton<EmployeeViewModel>();
            builder.Services.AddSingleton<EmployeeView>();

            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddSingleton<HomePageView>();

            return builder.Build();
        }
    }
}
