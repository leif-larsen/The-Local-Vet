using TheLocalVet.Languages;
using TheLocalVet.Pages.NearestVet;
using Xamarin.Forms;

namespace TheLocalVet.Pages
{
    public class RootPage : TabbedPage
    {
        public RootPage()
        {
            this.Children.Add(new NearestVetSearchPage { Title = AppResources.NearestVetPageTitle, Icon = "" });
            this.Children.Add(new InfoPage { Title = AppResources.InfoPageTitle, Icon = "" });
            //this.Children.Add(new EmergencyContactPage { Title = "Emergency", Icon = "" });
        }
    }
}
