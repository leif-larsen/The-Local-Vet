using System;

using Xamarin.Forms;

namespace TheLocalVet.Pages
{
	public class FilterPage : ContentPage
	{
		public FilterPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


