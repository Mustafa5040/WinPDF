using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Storage;
using WinPDF.ViewModels;

namespace WinPDF.Models
{
    public class PDFModel
    {
        public TabViewModel? AssignedTab { get; private set; }
        public string FilePath { get; }
        public PdfDocument Document { get; private set; }
        public string FileName => Path.GetFileName(FilePath);
        public int PageCount { get; private set; }
        public long FileSize { get; private set; }
        public string? Title { get; private set; }
        public string? Author { get; private set; }
        public DateTime? CreatedDate { get; private set; }
        public DateTime? ModifiedDate { get; private set; }
        public bool IsEncrypted { get; private set; }
        public PDFModel(string _FilePath, int _PageCount, long _FileSize, string? _Title, string? _Author, DateTime? _CreatedDate, DateTime? _ModifiedDate, bool _isEncrypted, TabViewModel _AssignedaTab)
        {
            AssignedTab = _AssignedaTab;
            FilePath = _FilePath;
            PageCount = _PageCount;
            FileSize = _FileSize;
            Title = _Title;
            Author = _Author;
            CreatedDate = _CreatedDate;
            ModifiedDate = _ModifiedDate;
            IsEncrypted = _isEncrypted;
        }
    }
}
