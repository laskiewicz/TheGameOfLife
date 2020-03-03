using WPFTheGameOfLife.Views;
using Prism.Ioc;
using System.Windows;
using WPFTheGameOfLife.GameOfLife;
using Prism.DryIoc;

namespace WPFTheGameOfLife
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    { 
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDispatcherTimerAdapter, DispatcherTimerAdapter>();
            containerRegistry.RegisterSingleton<GameLogic>();
        }
    }
}
