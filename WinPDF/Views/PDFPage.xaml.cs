using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Data.Pdf;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using WinPDF.Services;
using WinPDF.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinPDF.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PDFPage : Page
    {
        public PDFPage()
        {
            this.InitializeComponent();
            List<PDFViewModel> treeItems = new List<PDFViewModel>();
            treeItems.Add(new PDFViewModel("Proje özeti"));
            treeItems.Add(new PDFViewModel("ÝDA GENEL MÝMARÝSÝ"));
            mddtreeview.ItemsSource = treeItems;
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("DROP");
        }

        private async void Grid_Drop(object sender, DragEventArgs e)
        {
            if (e is DragEventArgs args) // == yapýnca neden olmadý? c sharp'ta is nedir? //bu ne la parameteri args olarak kullanamk için böyle mi yapacaðýz yani??
            {
                if (!args.DataView.Contains(StandardDataFormats.StorageItems)) return;
                var items = await e.DataView.GetStorageItemsAsync();

                List<BitmapImage> sayfalar = await PDFRenderer.RenderPDF(items[0].Path);

                mddItemRepeater.ItemsSource = sayfalar;
                BolumlerAppBarButton.IsEnabled = true;


            }
        }

        private void Page_Drop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("DROP");
        }

        private void BolumlerAppBarButtonClicked(object sender, RoutedEventArgs e)
        {
            if(BolumlerAppBarButton.IsChecked == true)
            {
                TreeViewGrid.Visibility = Visibility.Visible;
                return;
            }else
            {
                TreeViewGrid.Visibility = Visibility.Collapsed;
            }

        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;

        }
    }
}
