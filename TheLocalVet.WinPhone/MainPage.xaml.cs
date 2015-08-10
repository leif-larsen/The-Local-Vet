using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TheLocalVet;
using TheLocalVet.WinPhone.Resources;
using Xamarin.Forms;

namespace TheLocalVet.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = TheLocalVet.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}