using System;

using Xamarin.Forms;

using TheLocalVet.ViewModels;
using TheLocalVet.Pages;

namespace TheLocalVet
{
	public class App : Application
	{
		public App ()
		{	
		}

        public static Page GetMainPage()
        {
            return new RootPage();
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

