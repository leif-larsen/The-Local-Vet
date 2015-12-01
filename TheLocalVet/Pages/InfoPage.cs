using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TheLocalVet.Languages;
using TheLocalVet.ViewModels;
using Xamarin.Forms;

namespace TheLocalVet.Pages
{
    public class InfoPage : ContentPage
    {
        public InfoPage()
        {
            this.BindingContext = new InfoPageViewModel();
			Title = AppResources.InfoPageTitle;
            InitGui();
        }

        private void InitGui()
        {
            Label infoTextLabel = new Label { Text = AppResources.InfoTitleText };
            Editor infoText = new Editor { Text = AppResources.InfoText };
            infoText.SetBinding(IsFocusedProperty, "IsFocused");
            infoText.SetBinding(Editor.IsEnabledProperty, "IsFocused");

            //Label feedbackTextLabel = new Label { Text = AppResources.FeedbackTitleText };
            //Editor feedbackText = new Editor { Text = AppResources.FeedbackText };

            Button sendFeedbackButton = new Button { Text = AppResources.SendFeedbackButtonText };
            sendFeedbackButton.SetBinding(Button.CommandProperty, "SendFeedbackCommand");

            var content = new StackLayout
            {
                Children =
                {
                    infoTextLabel,
                    infoText,
                    //feedbackTextLabel,
                    //feedbackText,
                    sendFeedbackButton,
                }
            };

            Content = new ContentView
            {
                Padding = new Thickness(20),
                Content = content
            };
        }
    }
}
