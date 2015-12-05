using System;
using System.Globalization;
using TheLocalVet.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(TheLocalVet.WinPhone.Helpers.Localize))]
namespace TheLocalVet.WinPhone.Helpers
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture;
        }
    }
}
