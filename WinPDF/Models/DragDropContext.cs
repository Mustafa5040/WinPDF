using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;

namespace WinPDF.Models
{
    public class DragDropContext
    {
        private object sender { get; set; }
        private object EventArgs { get; set; }
        public DragDropContext(object sender, object dragEventsArgs)
        {
            this.sender = sender;
            this.EventArgs = dragEventsArgs;
        }
        public object getSender()
        {
            return sender;
        }
        public void setSender(object _sender)
        {
            sender = _sender;
        }

        public object getEventArgs()
        {
            return EventArgs;
        }
        public void setEventArgs(object _eventArgs)
        {
            EventArgs = _eventArgs;
        }

    }
}
