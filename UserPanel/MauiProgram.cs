using Microsoft.Extensions.Logging;
using UserPanel.Services;
using UserPanel.ViewModels.Login;
using UserPanel.ViewModels;
using UserPanel.Views.Auth;
using UserPanel.Views.Profile;
using UserPanel.Views.Base;
using UserPanel.Views.Items;
using UserPanel.Views.Hero;
namespace UserPanel
{
    public static class MauiProgram
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });
            builder.Logging.AddDebug();
            // Регистрация API-клиентов
            var baseAddress = "http://127.0.0.1:8000/encyclopedia/";
            builder.Services.AddApiHttpClient<RegisterService>(baseAddress);
            builder.Services.AddApiHttpClient<ArticleService>(baseAddress);
            builder.Services.AddApiHttpClient<HeroService>(baseAddress);
            builder.Services.AddApiHttpClient<AuthService>(baseAddress);
            builder.Services.AddApiHttpClient<ItemService>(baseAddress);
            // Регистрация страниц и ViewModel
            builder.Services.AddTransient<ArticleDetailsPage>();
            builder.Services.AddTransient<ItemsDetailsPage>();
            builder.Services.AddTransient<HeroDetailsPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<HeroesPage>();
            builder.Services.AddTransient<ItemsPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<ArticleViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<ItemViewModel>();
            builder.Services.AddTransient<HeroViewModel>();
            var app = builder.Build();
            ServiceProvider = app.Services;
            return app;
        }
    }
}