using System;
using TheLocalVet.Interfaces;
using Xamarin.Forms;
using MessageUI;

[assembly:Dependency(typeof(TheLocalVet.iOS.Helpers.EmailSender))]
namespace TheLocalVet.iOS.Helpers
{
	public class EmailSender : IMailSender
	{
		public void SendMail(string to, string subject)
		{
			/*MFMailComposeViewController mailController;

			if (MFMailComposeViewController.CanSendMail) 
			{
				mailController = new MFMailComposeViewController ();
				mailController.SetToRecipients (new string[] { to });
				mailController.SetSubject (subject);

				mailController.Finished += (object sender, MFComposeResultEventArgs e) => {
					e.Controller.DismissViewController(true, null);
				};

				mailController.PresentViewController ();
			}*/

			string mailTo = string.Format ("mailto:{0}?Subject={1}", to, subject);
			Device.OpenUri (new Uri (mailTo));
		}
	}
}

