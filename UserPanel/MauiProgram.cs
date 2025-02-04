using Microsoft.Extensions.Logging;
using UserPanel.Services;
using UserPanel.ViewModels.Login;
using UserPanel.ViewModels;
using UserPanel.Views.Auth;
using UserPanel.Views.Profile;
using UserPanel.Views.Base;
using UserPanel.Views.Hero;
using UserPanel.Views.Items;
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
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
            builder.Logging.AddDebug();

            // Регистрация API-клиентов
            builder.Services.AddApiHttpClient<RegisterService>("http://127.0.0.1:8000/encyclopedia/");
            builder.Services.AddApiHttpClient<AuthService>("http://127.0.0.1:8000/encyclopedia/");
            builder.Services.AddApiHttpClient<ArticleService>("http://127.0.0.1:8000/encyclopedia/");
            builder.Services.AddApiHttpClient<HeroService>("http://127.0.0.1:8000/encyclopedia/");
            builder.Services.AddApiHttpClient<ItemService>("http://127.0.0.1:8000/encyclopedia/");

            // Регистрация страниц и ViewModel
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<ArticlesViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ArticleDetailsPage>();
            builder.Services.AddTransient<HeroesViewModel>();
            builder.Services.AddTransient<HeroesPage>();
            builder.Services.AddTransient<HeroDetailsPage>();
            builder.Services.AddTransient<ItemsViewModel>();
            builder.Services.AddTransient<ItemsPage>();

            var app = builder.Build();
            ServiceProvider = app.Services;
            return app;
        }
    }
}