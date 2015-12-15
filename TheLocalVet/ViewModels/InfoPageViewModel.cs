using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TheLocalVet.Interfaces;
using Xamarin.Forms;
using TheLocalVet.Languages;
using Plugin.Messaging;

namespace TheLocalVet.ViewModels
{
    public class InfoPageViewModel : BaseViewModel
    {
        public RelayCommand SendFeedbackCommand { get; private set; }

        public bool IsFocused { get { return true; } set { OnPropertyChanged("IsFocused"); } }

        public InfoPageViewModel()
        {
            SendFeedbackCommand = new RelayCommand(SendFeedback);
            SendFeedbackCommand.IsEnabled = true;
        }

        private void SendFeedback()
		{
			var emailTask = MessagingPlugin.EmailMessenger;
			if (emailTask.CanSendEmail) 
				emailTask.SendEmail (new EmailMessageBuilder().To("me@leiflarsen.org").Subject(AppResources.FeedbackEmailSubject).Build());
        }
    }
}
