using System;
using System.Collections.Generic;

using Xamarin.Forms;
using TheLocalVet.ViewModels;
using TheLocalVet.Models;
using System.Diagnostics;

namespace TheLocalVet.Pages
{
	public partial class NearestVetSearchResultPage : ContentPage
	{
		private NearestVetSearchResultViewModel _vm;
		private INavigation _nav;

		public NearestVetSearchResultPage (string place, double latittude, double longitude, double distance, INavigation nav)
		{
			InitializeComponent ();
			_vm = new NearestVetSearchResultViewModel(place, nav, latittude, longitude, distance);
			BindingContext = _vm;
			_vm.OnSearchForVetFailed += OnSearchForVetFailed;
			GetVets ();
			NavigationPage.SetHasNavigationBar(this, true);
			_nav = nav;
		}

		private async void GetVets()
		{
			await _vm.GetNearestVet();
		}

		private async void OnSearchForVetFailed (object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void OnSingleVetSelected(object sender, SelectedItemChangedEventArgs e)
		{
			VetModel vet = e.SelectedItem as VetModel;

			await _nav.PushAsync(new NearestVetSinglePage(vet));
		}
	}
}

