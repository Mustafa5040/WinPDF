using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace WinPDF.Services
{
    public static class InteractionServices
    {
        /// <summary>
        /// Shows a basic content dialog that consists of only a text and an OK button
        /// </summary>

        public static async Task<ContentDialogResult> ShowNotifyTextContentDialog(XamlRoot _xamlRoot, String titleText, String contentText, String okButtonText)
        {

            ContentDialog dialog = new ContentDialog();

            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog.XamlRoot = _xamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = titleText;
            dialog.PrimaryButtonText = okButtonText;
            dialog.DefaultButton = ContentDialogButton.Primary;

            Grid grid = new Grid();
            TextBlock contentTextBlock = new TextBlock();
            contentTextBlock.Text = contentText;
            grid.Children.Add(contentTextBlock);
            dialog.Content = grid;
            return await dialog.ShowAsync();

        }
    }
}
