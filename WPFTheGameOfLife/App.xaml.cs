using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WPFTheGameOfLife.GameOfLife;
using WPFTheGameOfLife.ViewModels;
using WPFTheGameOfLife.Views;

namespace WPFTheGameOfLife
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDispatcherTimerAdapter, DispatcherTimerAdapter>();
            services.AddSingleton<GameLogic>();

            services.AddTransient<ShellViewModel>();

            services.AddTransient<SplashView>();
            services.AddTransient<SplashViewModel>();

            services.AddTransient<BoardView>();
            services.AddTransient<BoardViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
