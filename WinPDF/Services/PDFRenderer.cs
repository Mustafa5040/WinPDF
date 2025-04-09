using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.Storage.Streams;
using WinPDF.Views;

namespace WinPDF.Services
{
    public static class PDFRenderer
    {

        public static async Task<List<BitmapImage>> RenderPDF(string? FilePath)
        {
            IStorageFile file = await StorageFile.GetFileFromPathAsync(FilePath);
            PdfDocument pdfDoc = await PdfDocument.LoadFromFileAsync(file);
            List<BitmapImage> pages = new List<BitmapImage>();
            for(uint i = 0; i < pdfDoc.PageCount; i++)
            {
                Windows.Data.Pdf.PdfPage page = pdfDoc.GetPage(i);
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    await page.RenderToStreamAsync(stream);
                    BitmapImage bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(stream);
                    pages.Add(bitmapImage);
                }
            }
            return pages;
            
        }


            
            
        


    }
}
