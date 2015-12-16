using System;
using Xamarin.Forms;
using TheLocalVet.Models;

namespace TheLocalVet.ViewModels
{
	public class FilterPageViewModel : BaseViewModel
	{
		private INavigation _nav;

		public event EventHandler<FilterEventArgs> OnFilterUpdated;

		public RelayCommand CloseWindowCommand { get; private set; }
		public RelayCommand ResetFilterCommand { get; private set; }

		private int _selectedFilterType;

		public int SelectedFilterType
		{
			get { return _selectedFilterType; }
			set 
			{
				_selectedFilterType = value;
				OnPropertyChanged ("SelectedFilterType");
				OnPropertyChanged ("SelectedCompetency");
				OnPropertyChanged ("SelectedHomevisit");
				OnPropertyChanged ("IsCompetencyAvailable");
				OnPropertyChanged ("IsHomeVisitAvailable");
			}
		}

		public bool IsCompetencyAvailable 
		{
			get 
			{ 
				if (SelectedFilterType == 0)
					return true;
				else
					return false;
			}
		}

		private int _selectedCompetency;

		public int SelectedCompetency 
		{
			get { return _selectedCompetency; }
			set 
			{
				_selectedCompetency = value;
				OnPropertyChanged ("SelectedCompetency");
			}
		}

		public bool IsHomeVisitAvailable 
		{
			get 
			{ 
				if (SelectedFilterType != 0)
					return true;
				else
					return false;
			}
		}

		private int _selectedHomevisit;

		public int SelectedHomeVisit
		{
			get { return _selectedHomevisit; }
			set 
			{
				_selectedHomevisit = value;
				OnPropertyChanged ("SelectedHomevisit");
			}
		}

		public FilterPageViewModel (INavigation nav)
		{
			_nav = nav;

			CloseWindowCommand = new RelayCommand (CloseWindow);
			CloseWindowCommand.IsEnabled = true;

			ResetFilterCommand = new RelayCommand (ResetFilter);
			ResetFilterCommand.IsEnabled = true;
		}

		private void RaiseOnFilterUpdated(FilterEventArgs args)
		{
			var handler = OnFilterUpdated;
			if (handler != null)
				handler (this, args);
		}

		private async void CloseWindow()
		{
			string filterType = string.Empty;
			string filterValue = string.Empty;

			switch(SelectedFilterType)
			{
			case 0:
				filterType = "MainCompetency";
				filterValue = GetCompetencyValue ();
				break;
			case 1:
				filterType = "HomeVisit";
				filterValue = GetHomevisitValue ();
				break;
			}
		
			RaiseOnFilterUpdated (new FilterEventArgs { FilterType = filterType, FilterValue = filterValue });
			await _nav.PopAsync ();
		}

		private async void ResetFilter()
		{
			string filterType = "reset";
			string filterValue = string.Empty;

			RaiseOnFilterUpdated (new FilterEventArgs { FilterType = filterType, FilterValue = filterValue });
			await _nav.PopAsync ();
		}

		private string GetCompetencyValue()
		{
			string returnString = string.Empty;

			switch(SelectedCompetency)
			{
			case 0:
				returnString = "smallvet";
				break;
			case 1:
				returnString = "bigvet";
				break;
			}

			return returnString;
		}

		private string GetHomevisitValue()
		{
			string returnString = string.Empty;

			switch(SelectedCompetency)
			{
			case 0:
				returnString = "true";
				break;
			case 1:
				returnString = "false";
				break;
			default:
				break;
			}

			return returnString;
		}
	}
}

