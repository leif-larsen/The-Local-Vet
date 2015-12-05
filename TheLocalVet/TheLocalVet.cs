using System;

using Xamarin.Forms;

using TheLocalVet.ViewModels;
using TheLocalVet.Pages;
using TheLocalVet.Interfaces;
using TheLocalVet.Languages;

namespace TheLocalVet
{
	public class App : Application
	{
        private static Page _mainPage;

		public App ()
		{
            if (Device.OS != TargetPlatform.WinPhone)
                AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

			MainPage = new NavigationPage(new RootPage ());
            _mainPage = MainPage;
		}

        public static Page GetMainPage()
        {
            if (_mainPage != null)
                return _mainPage;
            else
                return new NavigationPage(new RootPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

