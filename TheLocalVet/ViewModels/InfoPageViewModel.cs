using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TheLocalVet.Interfaces;
using TheLocalVet.Languages;
using Xamarin.Forms;

namespace TheLocalVet.ViewModels
{
    public class InfoPageViewModel : BaseViewModel
    {
        private IMailSender _mail;
        public RelayCommand SendFeedbackCommand { get; private set; }

        public bool IsFocused { get { return true; } set { OnPropertyChanged("IsFocused"); } }

        public InfoPageViewModel()
        {
            _mail = DependencyService.Get<IMailSender>();
            SendFeedbackCommand = new RelayCommand(SendFeedback);
            SendFeedbackCommand.IsEnabled = true;
        }

        private void SendFeedback()
        {
            _mail.SendMail("me@leiflarsen.org", AppResources.FeedbackEmailSubject);
        }
    }
}
