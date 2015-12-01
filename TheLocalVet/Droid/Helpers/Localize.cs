using System;
using System.Globalization;

using Xamarin.Forms;

using TheLocalVet.Interfaces;

[assembly:Dependency(typeof(TheLocalVet.Droid.Helpers.Localize))]
namespace TheLocalVet.Droid.Helpers
{
	public class Localize : ILocalize
	{
		public CultureInfo GetCurrentCultureInfo()
		{
			var androidLocale = Java.Util.Locale.Default;
			var netLanguage = androidLocale.ToString().Replace ("_", "-"); // turns pt_BR into pt-BR
			return new System.Globalization.CultureInfo(netLanguage);
		}
	}
}

