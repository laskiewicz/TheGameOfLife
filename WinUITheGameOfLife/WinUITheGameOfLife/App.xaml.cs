﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using TheGameOfLifeLibrary;
using WinUITheGameOfLife.Services;
using WinUITheGameOfLife.ViewModels;
using WinUITheGameOfLife.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUITheGameOfLife
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            Ioc.Default.ConfigureServices(ConfigureServices());
            // this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            m_window = Ioc.Default.GetService<ShellView>();
            m_window.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        //private void OnSuspending(object sender, SuspendingEventArgs e)
        //{
        //    // Save application state and stop any background activity
        //}

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

            services.AddSingleton<SettingsPage>();
            services.AddSingleton<SettingsViewModel>();

            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();

            return services.BuildServiceProvider();
        }

        public static Window m_window;
    }
}
