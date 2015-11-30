using TheLocalVet.Languages;
using TheLocalVet.Pages.NearestVet;
using Xamarin.Forms;

namespace TheLocalVet.Pages
{
    public class RootPage : TabbedPage
    {
        public RootPage()
        {
			this.Children.Add(new NearestVetSearchPage (this.Navigation) { Title = AppResources.NearestVetPageTitle });
            this.Children.Add(new InfoPage { Title = AppResources.InfoPageTitle});
            //this.Children.Add(new EmergencyContactPage { Title = "Emergency", Icon = "" });
        }
    }
}
