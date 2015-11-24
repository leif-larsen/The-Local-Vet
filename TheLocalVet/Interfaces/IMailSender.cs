using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLocalVet.Interfaces
{
    public interface IMailSender
    {
        void SendMail(string to, string subject);
    }
}
