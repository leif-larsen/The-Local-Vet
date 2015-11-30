using System;
using Xamarin.Forms;
using TheLocalVet.Interfaces;
using UIKit;
using Foundation;
using System.Diagnostics;

[assembly:Dependency(typeof(TheLocalVet.iOS.Helpers.PhoneDialer))]
namespace TheLocalVet.iOS.Helpers
{
	public class PhoneDialer : IDialer
	{
		public bool Dial(string number, string name)
		{
			try 
			{
				//PhoneCallTask
			}
			catch (Exception ex) 
			{
				Debug.WriteLine ("Couldn't make a call - {0}", ex.Message);
			}
			return true;
		}
	}
}

