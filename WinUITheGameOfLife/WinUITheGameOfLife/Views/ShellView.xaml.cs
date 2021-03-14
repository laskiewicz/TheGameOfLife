using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using WinUITheGameOfLife.ViewModels;

namespace WinUITheGameOfLife.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public sealed partial class ShellView : Window
    {
        public ShellView()
        {
            this.InitializeComponent();
            ViewModel = Ioc.Default.GetService<ShellViewModel>();
        }
        public ShellViewModel ViewModel { get; set; }
        public Frame GetNavigationFrame()
            => MainContentFrame;

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(typeof(HelpView));
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.SelectedItemContainer != null)
            {
                var navItemTag = args.SelectedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }
        private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")
            {
                _page = typeof(SettingsPage);
            }
            else
            {
                switch (navItemTag)
                {
                    case "HelpView":
                        _page = typeof(HelpView);
                        break;
                    case "BoardView":
                        _page = typeof(BoardView);
                        break;
                }
            }
            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = MainContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                MainContentFrame.Navigate(_page, null, transitionInfo);
            }
        }
    }
}
