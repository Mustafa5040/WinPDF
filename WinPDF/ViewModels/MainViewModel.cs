using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using WinPDF.Models;

namespace WinPDF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ICommand AddTabCommand { get; }
        public ICommand CloseTabCommand { get; }
        public ObservableCollection<TabViewModel> TabsCollection { get; set; } = new ObservableCollection<TabViewModel>();

        public MainViewModel()
        {
            AddTabCommand = new RelayCommand<TabOperationContext>(AddTab);
            CloseTabCommand = new RelayCommand<EventContext>(CloseTab);
        }
        private void AddTab(TabOperationContext context)
        {
            TabsCollection.Add(context.gettabView());
            (context.getSender() as TabView).SelectedItem = context.gettabView();
        }
        public void AddHomeTab(object sender)
        {
            AddTabCommand.Execute(new TabOperationContext(sender,new TabModels().HomeTabModel()));
        }
        public void CloseTab(EventContext context)
        {
            TabViewTabCloseRequestedEventArgs args = (context.getEventArgs() as TabViewTabCloseRequestedEventArgs);
            if (TabsCollection.Count >= 1)
            {
                TabsCollection.Remove(args.Item as TabViewModel);
            }
        }
    }
}
