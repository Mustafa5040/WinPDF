using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using WinPDF.Models;
using WinPDF.Services;

namespace WinPDF.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public IRelayCommand<DragDropContext> DropCommand { get; set; }
        public IRelayCommand<DragDropContext> DragOverCommand { get; set; }
        public IRelayCommand<object> OpenFileCommand { get; set; }

        private bool _isOpeningFile = false;
        public bool IsOpeningFile // get set öğren
        {
            get => _isOpeningFile;
            set => SetProperty(ref _isOpeningFile, value);
        }
        public bool IsButtonActive // get set öğren
        {
            get => !_isOpeningFile;
            set => SetProperty(ref _isOpeningFile, !value);
        }
        public HomeViewModel()
        {
            DropCommand = new RelayCommand<DragDropContext>(onDrop); //IRelayCommand'dan farkı
            DragOverCommand = new RelayCommand<DragDropContext>(onDragOver);
            OpenFileCommand = new RelayCommand<object>(onOpenFile);
        }
        private async void onDrop(DragDropContext context)
        {

            if (context.getEventArgs() is DragEventArgs args) // == yapınca neden olmadı? c sharp'ta is nedir? //bu ne la parameteri args olarak kullanamk için böyle mi yapacağız yani??
            {
                if (!args.DataView.Contains(StandardDataFormats.StorageItems)) return;
                var items = await args.DataView.GetStorageItemsAsync();

                if (items.Count > 0)
                {

                    String outputText = "";
                    for (int i = 0; i < items.Count; i++)
                    {
                        outputText += items[i].Name + "\n";
                    }
                    await InteractionServices.ShowNotifyTextContentDialog((context.getSender() as UIElement).XamlRoot, "Aşağıdaki Dosyaları sürüklediniz: ", outputText, "OK");

                }


            }

        }
        private async void onDragOver(DragDropContext context)
        {
            //Debug.WriteLine("parameter: " + parameter);
            //Debug.WriteLine("ONDRAGOVER");
            if (context.getEventArgs() is DragEventArgs args)
            {
                Debug.WriteLine("DRAGOVER STEP2");
                args.AcceptedOperation = DataPackageOperation.Copy;
            }
        }

        private async void onOpenFile(object parameter)
        {
            Button senderButton = ((parameter as RoutedEventArgs).OriginalSource as Button);
            senderButton.IsEnabled = false;
            Debug.WriteLine("ON OPEN FILE");
            IReadOnlyList<StorageFile> selectedFiles = await FileOperationService.OpenFileDialog([".pdf"], FileOpenTypesEnum.Multiple);
            String outputText = "";
            for (int i = 0; i < selectedFiles.Count; i++)
            {
                outputText += selectedFiles[i].DisplayName + "\n";
            }
            if (parameter is RoutedEventArgs args)
            {
                await InteractionServices.ShowNotifyTextContentDialog((args.OriginalSource as UIElement).XamlRoot, "Aşağıdaki Dosyalar Seçildi", outputText, "TAMAM");
                senderButton.IsEnabled = true;
            }



        }





    }
}
