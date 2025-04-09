using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using WinPDF.Models;

namespace WinPDF.ViewModels
{
    public partial class TabViewModel : ObservableObject
    {
        private string _title;
        private string _description;
        private TabTypesEnum _type;
        private Type _pageType;
        private IconSource _sourceIcon;
        private Frame _contFrame;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public TabTypesEnum Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        public Type PageType
        {
            get => _pageType;
            set => SetProperty(ref _pageType, value);
        }

        public IconSource SourceIcon
        {
            get => _sourceIcon;
            set => SetProperty(ref _sourceIcon, value);
        }

        public Frame ContFrame
        {
            get => _contFrame;
            set => SetProperty(ref _contFrame, value);
        }

        public TabViewModel(string title, string description, TabTypesEnum type, Type pageType, IconSource sourceIcon, Frame contentFrame)
        {
            Title = title;
            Description = description;
            Type = type;
            PageType = pageType;
            SourceIcon = sourceIcon;
            ContFrame = contentFrame;

            ContFrame.VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Stretch;
            ContFrame.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch;
        }
    }
}
