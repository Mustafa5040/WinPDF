using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Text;
using System;
using Windows.Storage.Pickers;
using Windows.Storage;
using WinPDF.Services;
using WinPDF.Models;
using WinPDF.ViewModels;
using System.Diagnostics;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.ApplicationModel.DataTransfer;

namespace WinPDF.Views
{
    public sealed partial class HomePage : Page
    {
        MainViewModel _mainViewModel;
        HomeViewModel _homeViewModel;
        public HomePage()
        {
            this.InitializeComponent();
            _mainViewModel = new MainViewModel();
            _homeViewModel = new HomeViewModel();
            HomeNewActionsStackPanel.DataContext = _homeViewModel;
            HomeOpenFileButton.DataContext = _homeViewModel;
        }

        private void HomeNewActionsStackPanel_Drop(object sender, Microsoft.UI.Xaml.DragEventArgs e)
        {
            _homeViewModel.DropCommand.Execute(new DragDropContext(sender,e));
        }

        private void HomeNewActionsStackPanel_DragOver(object sender, Microsoft.UI.Xaml.DragEventArgs e)
        {
            _homeViewModel.DragOverCommand.Execute(new DragDropContext(sender,e));
        }
    }
}
