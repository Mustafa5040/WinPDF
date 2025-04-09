using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinPDF.ViewModels;

namespace WinPDF.Models
{
    public class TabOperationContext
    {
        private object sender { get; set; }
        private TabViewModel tabViewModel { get; set; }
        public TabOperationContext(object _sender, TabViewModel _tabView)
        {
            this.sender = _sender;
            this.tabViewModel = _tabView;
        }
        public object getSender()
        {
            return sender;
        }
        public void setSender(object _sender)
        {
            sender = _sender;
        }
        public TabViewModel gettabView()
        {
            return tabViewModel;
        }
        public void setEventArgs(TabViewModel _tabViewModel)
        {
            tabViewModel = _tabViewModel;
        }
    }
}
