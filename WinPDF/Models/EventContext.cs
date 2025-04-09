using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPDF.Models
{
    public class EventContext
    {
        private object Sender { get; set; }
        private object EventArgs { get; set; }
        public EventContext(object _sender, object _eventArgs)
        {
            this.Sender = _sender;
            this.EventArgs = _eventArgs;
        }
        public object getSender()
        {
            return Sender;
        }
        public void setSender(object _sender)
        {
            Sender = _sender;
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
