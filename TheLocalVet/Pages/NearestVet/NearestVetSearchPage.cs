using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TheLocalVet.Languages;
using TheLocalVet.Models;
using TheLocalVet.ViewModels;
using Xamarin.Forms;

namespace TheLocalVet.Pages.NearestVet
{
    public class NearestVetSearchPage : ContentPage
    {
		public NearestVetSearchPage(INavigation nav)
        {
            this.BindingContext = new NearestVetSearchPageViewModel(nav);
			Title = AppResources.NearestVetPageTitle;
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, false);
            InitGui();
        }

        private void InitGui()
        {
            Label searchLabel = new Label { Text = AppResources.SearchNearestVetLabel };
            Picker searchType = new Picker
            {
                Title = AppResources.SearchNearestVetPickerText,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            searchType.SetBinding(Picker.SelectedIndexProperty, "SelectedSearchType");
            searchType.Items.Add(AppResources.SearchNearestVetLocation);
            searchType.Items.Add(AppResources.SearchNearestVetPlace);
            searchType.SelectedIndex = 0;

            Picker distancePicker = new Picker
            {
                Title = AppResources.SearchNearestVetDistance,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            distancePicker.SetBinding(Picker.SelectedIndexProperty, "Distance");

            var distances = Enum.GetValues(typeof(DistanceToVet));
            foreach(DistanceToVet value in distances)
            {
                string title;

                switch(value)
                {
                    case DistanceToVet.km1:
                        title = "1 km";
                        break;
                    case DistanceToVet.km2:
                        title = "2 km";
                        break;
                    case DistanceToVet.km5:
                        title = "5 km";
                        break;
                    case DistanceToVet.km10:
                        title = "10 km";
                        break;
                    case DistanceToVet.km20:
                        title = "20 km";
                        break;
                    case DistanceToVet.km50:
                        title = "50 km";
                        break;
                    case DistanceToVet.km100:
                        title = "100 km";
                        break;
                    default:
                        title = "10 km";
                        break;
                }

                distancePicker.Items.Add(title);
            }

            Entry searchPlaceEntry = new Entry();
            searchPlaceEntry.SetBinding(Entry.TextProperty, "SearchPlace");

            Button searchButton = new Button { Text = AppResources.Search };
            searchButton.SetBinding(Button.CommandProperty, "SearchCommand");

            var content = new StackLayout
            {
                Children =
                {
                    searchLabel,
                    searchType,
                    distancePicker,
                    searchPlaceEntry,
                    searchButton,
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
