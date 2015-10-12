using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLocalVet.Models
{
    public class MessagesEventArgs : EventArgs
    {
        public string Message;

        public MessagesEventArgs()
        {
            Message = string.Empty;
        }

        public MessagesEventArgs(string message)
        {
            Message = message;
        }
    }
}
