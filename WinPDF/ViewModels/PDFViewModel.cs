using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinPDF.Models;

namespace WinPDF.ViewModels
{
    public class PDFViewModel
    {
        public string name;
        public PDFViewModel(string name)
        {
            this.name = name;
        }

        public void ExtractText(PDFModel _pdfmodel)
        {

        }

    }
}
