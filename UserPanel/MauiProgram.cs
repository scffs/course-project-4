using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using UserPanel.Services;
using UserPanel.ViewModels;
using UserPanel.Views.Auth;

namespace UserPanel
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

            // Регистрация сервисов
            builder.Services.AddHttpClient<RegisterService>(client =>
            {
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
            });
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<RegisterPage>();

            var app = builder.Build();

            ServiceProvider = app.Services;

            return app;
        }
    }
}
