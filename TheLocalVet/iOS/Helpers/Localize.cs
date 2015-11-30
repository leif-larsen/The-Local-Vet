using System;
using TheLocalVet.Interfaces;
using Xamarin.Forms;
using System.Globalization;
using Foundation;

[assembly:Dependency(typeof(TheLocalVet.iOS.Helpers.Localize))]
namespace TheLocalVet.iOS.Helpers
{
	public class Localize : ILocalize
	{
		public CultureInfo GetCurrentCultureInfo()
		{
			string netLanguage = "en";

			if (NSLocale.PreferredLanguages.Length > 0) 
			{
				var pref = NSLocale.PreferredLanguages [0];
				netLanguage = pref.Replace ("_", "-");
			}

			return new CultureInfo (netLanguage);
		}
	}
}

