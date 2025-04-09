using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPDF.Services
{
    public class NavigationService
    {
        private Frame _frame;
        public NavigationService(Frame __frame) 
        { 
        _frame = __frame;
        }
        public void Navigate(Type pageType)
        {

            _frame.Navigate(pageType);
        }
        public void GoBack()
        {
            if (_frame.CanGoBack)
            {
                _frame.GoBack();
            }
        }
    }
}
