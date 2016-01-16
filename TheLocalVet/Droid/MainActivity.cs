using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Parse;
using Acr.UserDialogs;

namespace TheLocalVet.Droid
{
	[Activity (Label = "Lokal Dyrlege", Icon = "@drawable/ic_launcher", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			UserDialogs.Init (this);

			ParseClient.Initialize("eKWSJpWP5VDZV8QKfwVIVKLnjvPxsdhvl2lKI2Dd", "aKV1AIEnUtpuRVco86b6euTdz1e0PANoGmllJ9sD");

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}
	}
}

