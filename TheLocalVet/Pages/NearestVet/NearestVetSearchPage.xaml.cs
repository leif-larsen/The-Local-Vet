using System;
using System.Collections.Generic;

using Xamarin.Forms;
using TheLocalVet.ViewModels;

namespace TheLocalVet.Pages
{
	public partial class NearestVetSearchPage : ContentPage
	{
		public NearestVetSearchPage (INavigation nav)
		{
			InitializeComponent ();
			Title = "Søk";
			this.BindingContext = new NearestVetSearchPageViewModel(nav);
			NavigationPage.SetHasNavigationBar(this, true);
			NavigationPage.SetHasBackButton(this, false);
		}
	}
}

