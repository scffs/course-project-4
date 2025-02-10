using AdminPanel.Services;
using AdminPanel.Views;
using LoginViewModel = AdminPanel.ViewModels.Login.LoginViewModel;

namespace AdminPanel;

public static class MauiProgram
{
    public static IServiceProvider? ServiceProvider { get; private set; }

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

        // Регистрация сервисов
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<BaseService>();
        builder.Services.AddApiHttpClient<AuthService>("http://localhost:8000/encyclopedia");

        builder.Services.AddTransient<LoginViewModel>();

        var app = builder.Build();

        ServiceProvider = app.Services;

        return app;
    }
}