using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Parse;

namespace TheLocalVet.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			ParseClient.Initialize("eKWSJpWP5VDZV8QKfwVIVKLnjvPxsdhvl2lKI2Dd", "aKV1AIEnUtpuRVco86b6euTdz1e0PANoGmllJ9sD");

			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB (149,149,149);
			UINavigationBar.Appearance.TintColor = UIColor.White;

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

