using System;
using System.CodeDom.Compiler;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

using TheLocalVet_Shared;

namespace TheLocalVet_iOS
{
	partial class EmergencyFront : UIViewController
	{
		private Counties myCounties = new Counties();

		public EmergencyFront (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();


		}
	}
}
