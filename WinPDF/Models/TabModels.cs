using Microsoft.UI.Xaml.Controls;
using WinPDF.ViewModels;
using WinPDF.Views;

namespace WinPDF.Models
{
    public class TabModels
    {
        public TabModels() { }
        public TabViewModel HomeTabModel()
        {
            Frame homeFrame = new Frame();
            homeFrame.Navigate(typeof(HomePage));
            return new TabViewModel("Home Tab", "This is Home Page description", TabTypesEnum.HomePage, typeof(HomePage), new SymbolIconSource() { Symbol = Symbol.Home }, homeFrame);
        }
        public TabViewModel PDFTabModel()
        {
            Frame pdfFrame = new Frame();
            pdfFrame.Navigate(typeof(PDFPage));
            return new TabViewModel("PDF Tab", "This is PDF Page description", TabTypesEnum.PDFView, typeof(PDFPage), new SymbolIconSource() { Symbol = Symbol.Document }, pdfFrame);
        }



    }
}
