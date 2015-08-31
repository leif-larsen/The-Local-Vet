using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TheLocalVet.Pages
{
    public class NearestVetPage : ContentPage
    {
        public NearestVetPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello nearest vet" }
                }
            };
        }
    }
}
