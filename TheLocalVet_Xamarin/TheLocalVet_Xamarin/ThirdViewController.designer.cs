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

namespace TheLocalVet_Xamarin
{
	[Register ("ThirdViewController")]
	partial class ThirdViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView FeedbackText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel FeedbackTitle { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (FeedbackText != null) {
				FeedbackText.Dispose ();
				FeedbackText = null;
			}
			if (FeedbackTitle != null) {
				FeedbackTitle.Dispose ();
				FeedbackTitle = null;
			}
		}
	}
}
