using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TheLocalVet.Pages
{
    public class EmergencyContactPage : MasterDetailPage
    {
        public EmergencyContactPage()
        {
            //var menuPage = new MenuPage();

            ////menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as Menu.MenuItem);

            //Master = menuPage;
            //Detail = new NavigationPage(new EmergencyContactPage());
        }

        void NavigateTo(Menu.MenuItem menu)
        {
            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            Detail = new NavigationPage(displayPage);

            IsPresented = false;
        }
    }
}
