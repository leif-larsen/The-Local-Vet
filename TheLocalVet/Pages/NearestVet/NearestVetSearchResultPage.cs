using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TheLocalVet.Models;
using TheLocalVet.ViewModels;
using Xamarin.Forms;

namespace TheLocalVet.Pages.NearestVet
{
    public class NearestVetSearchResultPage : ContentPage
    {
        NearestVetSearchResultViewModel _vm;

        public NearestVetSearchResultPage(string place, double latittude, double longitude, double distance)
        {
            _vm = new NearestVetSearchResultViewModel(place, latittude, longitude, distance);
            _vm.OnSearchForVetFailed += _vm_OnSearchForVetFailed;
            NavigationPage.SetHasNavigationBar(this, true);

            InitGui();
        }

        private async void _vm_OnSearchForVetFailed(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void InitGui()
        {
            ListView listView = new ListView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, new Binding(path: "Address"));

            listView.ItemTemplate = cell;
            listView.ItemSelected += SingleVetetIsSelectedAsync;

            await _vm.GetNearestVet();
            listView.ItemsSource = _vm.Vets;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(left: 0, right: 0, bottom:0, top: Device.OnPlatform(iOS: 20, Android: 0, WinPhone: 0)),
                Children = { listView }
            };
        }

        private async void SingleVetetIsSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new NearestVetSinglePage(e.SelectedItem as VetModel));
        }
    }
}
