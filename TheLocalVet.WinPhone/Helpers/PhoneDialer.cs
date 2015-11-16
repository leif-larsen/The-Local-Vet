using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(TheLocalVet.WinPhone.Helpers.PhoneDialer))]
namespace TheLocalVet.WinPhone.Helpers
{
    public class PhoneDialer : IDialer
    {
        public bool Dial(string number, string name)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            phoneCallTask.PhoneNumber = number;
            phoneCallTask.DisplayName = name;

            phoneCallTask.Show();

            return true;
        }
    }
}
