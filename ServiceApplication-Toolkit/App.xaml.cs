using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceApplication_Toolkit.MVVM.ViewModels;
using ServiceApplication_Toolkit.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceApplication_Toolkit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost? AppHost { get; set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<HttpClient>();
                    services.AddSingleton<DateTimeService>();
                    services.AddSingleton<WeatherService>();

                    services.AddSingleton<HomeViewModel>();
                    services.AddSingleton<SettingsViewModel>();
                    services.AddSingleton<MainWindowViewModel>();
                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var mainWindow = AppHost!.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}

