// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace TheLocalVet_iOS
{
	[Register ("ViewModel/EmergencyFront")]
	partial class EmergencyFront
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIPickerView countiesView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (countiesView != null) {
				countiesView.Dispose ();
				countiesView = null;
			}
		}
	}
}
