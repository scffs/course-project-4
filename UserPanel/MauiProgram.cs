using Microsoft.Extensions.Logging;
using UserPanel.Services;
using UserPanel.ViewModels;
using UserPanel.Views.Auth;

namespace UserPanel
{
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
      builder.Logging.AddDebug();

      // Регистрация сервисов
      builder.Services.AddApiHttpClient<RegisterService>("http://127.0.0.1:8000/api/");
      builder.Services.AddApiHttpClient<AuthService>("http://127.0.0.1:8000/api/");

      builder.Services.AddTransient<LoginPage>();
      builder.Services.AddTransient<BaseService>();
      builder.Services.AddTransient<RegisterPage>();

      builder.Services.AddTransient<LoginViewModel>();
      builder.Services.AddTransient<RegisterViewModel>();

      var app = builder.Build();

      ServiceProvider = app.Services;

      return app;
    }
  }
}