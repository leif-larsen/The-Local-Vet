using TheLocalVet.Pages.NearestVet;
using Xamarin.Forms;

namespace TheLocalVet.Pages
{
    public class RootPage : TabbedPage
    {
        public RootPage()
        {
            this.Children.Add(new NearestVetSearchPage { Title = "Nearest Vet", Icon = "" });
            //this.Children.Add(new EmergencyContactPage { Title = "Emergency", Icon = "" });
        }
    }
}
