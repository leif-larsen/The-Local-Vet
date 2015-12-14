using System;
using System.Collections.Generic;

using Xamarin.Forms;
using TheLocalVet.Models;
using TheLocalVet.ViewModels;

namespace TheLocalVet.Pages
{
	public partial class NearestVetSinglePage : ContentPage
	{
		public NearestVetSinglePage (VetModel vetModel)
		{
			InitializeComponent ();

			this.BindingContext = new NearestVetSingleViewModel(vetModel);
			NavigationPage.SetHasNavigationBar(this, true);
			NavigationPage.SetHasBackButton(this, true); 
		}
	}
}

