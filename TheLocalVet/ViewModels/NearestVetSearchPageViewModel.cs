using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Languages;
using TheLocalVet.Pages.NearestVet;
using Xamarin.Forms;

namespace TheLocalVet.ViewModels
{
    public class NearestVetSearchPageViewModel : BaseViewModel 
    {
        private INavigation _navigation;

        public RelayCommand SearchCommand { get; private set; }

        private string _searchPlace = string.Empty;

        public string SearchPlace
        {
            get { return _searchPlace; }
            set { _searchPlace = value; OnPropertyChanged("SearchPlace"); }
        }

        private string _selectedSearchType = AppResources.SearchNearestVetLocation;
        
        public string SelectedSearchType
        {
            get { return _selectedSearchType; }
            set { _selectedSearchType = value;  OnPropertyChanged("SelectedSearchType"); }
        }

        private string _error = string.Empty;

        public string Error
        {
            get { return _error; }
            set { _error = value;  OnPropertyChanged("Error"); }
        }

        public NearestVetSearchPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            SearchCommand = new RelayCommand(Search);
            SearchCommand.IsEnabled = true;
        }

        private async void Search()
        {
            if(SelectedSearchType.Equals(AppResources.SearchNearestVetLocation))
            {

            }
            else
            {
                if(string.IsNullOrEmpty(SearchPlace))
                {
                    Error = AppResources.SearchPlaceIsEmpty;
                }
                else
                {
                    await _navigation.PushAsync(new NearestVetSearchResultPage(SearchPlace));
                }
            }
        }
    }
}
