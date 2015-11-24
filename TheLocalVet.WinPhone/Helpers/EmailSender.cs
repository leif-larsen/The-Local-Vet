using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(TheLocalVet.WinPhone.Helpers.EmailSender))]
namespace TheLocalVet.WinPhone.Helpers
{
    public class EmailSender : IMailSender
    {
        public void SendMail(string to, string subject)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = subject;
            emailComposeTask.To = to;

            emailComposeTask.Show();
        }
    }
}
