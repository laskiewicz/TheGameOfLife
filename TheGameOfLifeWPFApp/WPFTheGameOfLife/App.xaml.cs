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
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var shellView = App.Current.Services.GetService<ShellView>();
            shellView.Show();
        }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDispatcherTimerAdapter, DispatcherTimerAdapter>();
            services.AddSingleton<GameLogic>();

            services.AddSingleton<ShellViewModel>();
            services.AddSingleton<ShellView>();

            services.AddSingleton<HelpView>();
            services.AddSingleton<HelpViewModel>();

            services.AddSingleton<BoardView>();
            services.AddSingleton<BoardViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
