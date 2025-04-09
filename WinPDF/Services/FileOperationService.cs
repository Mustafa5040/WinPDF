using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Diagnostics;
using Microsoft.UI.Xaml;
using WinPDF.Models;

namespace WinPDF.Services
{
    public static class FileOperationService
    {
        public static async Task<IReadOnlyList<StorageFile>> OpenFileDialog()
        {

            return await OpenFileDialog(PickerLocationId.DocumentsLibrary, ["*"], PickerViewMode.List, FileOpenTypesEnum.Single, App.MainWindow);

        }
        public static async Task<IReadOnlyList<StorageFile>> OpenFileDialog(string[] fileTypes, FileOpenTypesEnum FileOpenType)
        {

            return await OpenFileDialog(PickerLocationId.DocumentsLibrary, fileTypes, PickerViewMode.List, FileOpenType, App.MainWindow);

        }
        public static async Task<IReadOnlyList<StorageFile>> OpenFileDialog(PickerLocationId startingLoc, string[] fileTypes, PickerViewMode viewMode, FileOpenTypesEnum openType, Window window)
        {
            var openPicker = new FileOpenPicker();
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);
            openPicker.ViewMode = viewMode;
            openPicker.SuggestedStartLocation = startingLoc;
            Debug.WriteLine(fileTypes.Length);
            if (fileTypes != null)
            {
                for (int i = 0; i < fileTypes.Length; i++)
                {
                    openPicker.FileTypeFilter.Add(fileTypes[i]);
                }
            }

            switch (openType)
            {
                case FileOpenTypesEnum.Single:
                    var file = await openPicker.PickSingleFileAsync();
                    IReadOnlyList<StorageFile> singleFileList = new List<StorageFile> { file };
                    return singleFileList;

                case FileOpenTypesEnum.Multiple:
                    return await openPicker.PickMultipleFilesAsync();
            }
            return await openPicker.PickMultipleFilesAsync();
        }

    }

}
