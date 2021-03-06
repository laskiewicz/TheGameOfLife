﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Controls;
using WPFTheGameOfLife.Views;

namespace WPFTheGameOfLife.ViewModels
{
    public class ShellViewModel : ObservableRecipient
    {
        private Page _currentpage;
        public Page CurrentPage
        {
            get => _currentpage;
            set => SetProperty(ref _currentpage, value);
        }
        public ShellViewModel(HelpView splashView)//IRegionManager regionManager)
        {
            CurrentPage = splashView;
        }
    }
}
