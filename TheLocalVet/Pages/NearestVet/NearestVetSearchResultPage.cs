using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TheLocalVet.Models;
using TheLocalVet.ViewModels;
using Xamarin.Forms;
using TheLocalVet.Languages;
using System.Threading;

namespace TheLocalVet.Pages.NearestVet
{
    public class NearestVetSearchResultPage : ContentPage
    {
        NearestVetSearchResultViewModel _vm;
		private INavigation _nav;
		private ListView _listView = new ListView
		{
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.FillAndExpand
		};

		public NearestVetSearchResultPage(string place, double latittude, double longitude, double distance, INavigation nav)
        {
            _vm = new NearestVetSearchResultViewModel(place, latittude, longitude, distance);
            _vm.OnSearchForVetFailed += _vm_OnSearchForVetFailed;
            NavigationPage.SetHasNavigationBar(this, true);
			_nav = nav;

			ToolbarItem toolbarItem = new ToolbarItem ("Filter", null, async () => {
				await _nav.PushModalAsync(new FilterPage());
			}, 0, 0);

			//ToolbarItems.Add (toolbarItem);

            InitGui();
        }

        private async void _vm_OnSearchForVetFailed(object sender, EventArgs e)
        {
			await Navigation.PopAsync();
        }

        private async void InitGui()
        {
            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, new Binding(path: "Address"));

            _listView.ItemTemplate = cell;
            _listView.ItemSelected += SingleVetetIsSelectedAsync;

            await _vm.GetNearestVet();

			if (_vm.Vets.Count != 0) 
			{
				_listView.ItemsSource = _vm.Vets;

				Content = new StackLayout 
				{
					VerticalOptions = LayoutOptions.FillAndExpand,
					Padding = new Thickness (left: 0, right: 0, bottom: 0, top: Device.OnPlatform (iOS: 20, Android: 0, WinPhone: 0)),
					Children = { _listView }
				};
			} 
			else 
			{
				Content = new StackLayout 
				{
					VerticalOptions = LayoutOptions.FillAndExpand,
					Padding = new Thickness (left: 0, right: 0, bottom: 0, top: Device.OnPlatform (iOS: 20, Android: 0, WinPhone: 0)),
					Children = { new Label { Text = "No vets were found." } }
				};
			}
        }

        private async void SingleVetetIsSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
			VetModel vet = e.SelectedItem as VetModel;

			await _nav.PushAsync(new NearestVetSinglePage(vet));
        }
    }
}
