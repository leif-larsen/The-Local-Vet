using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TheLocalVet.Pages
{
    public class EmergencyContactPage : ContentPage
    {
        public EmergencyContactPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello Emergency" }
                }
            };
        }
    }
}
