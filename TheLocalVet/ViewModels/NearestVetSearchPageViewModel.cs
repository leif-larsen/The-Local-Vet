using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Interfaces;
using TheLocalVet.Languages;
using TheLocalVet.Models;
using TheLocalVet.Pages.NearestVet;
using Xamarin.Forms;

namespace TheLocalVet.ViewModels
{
    public class NearestVetSearchPageViewModel : BaseViewModel 
    {
        private INavigation _navigation;
        private IGeolocator _location;

        public RelayCommand SearchCommand { get; private set; }

        private string _searchPlace = string.Empty;

        public string SearchPlace
        {
            get { return _searchPlace; }
            set { _searchPlace = value; OnPropertyChanged("SearchPlace"); }
        }

        private int _selectedSearchType;
        
        public int SelectedSearchType
        {
            get { return _selectedSearchType; }
            set { _selectedSearchType = value;  OnPropertyChanged("SelectedSearchType"); }
        }

        private int _distance;

        public int Distance
        {
            get { return _distance; }
            set { _distance = value;  OnPropertyChanged("Distance"); }
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

            _location = DependencyService.Get<IGeolocator>();
            SelectedSearchType = 0;
            Distance = 3;
        }

        private async void Search()
        {
            if(SelectedSearchType == 0)
            {
                if(_location != null)
                {
                    var position = await _location.GetPositionAsync(5000);
                    double distance = GetChoosenDistance();
                    Debug.WriteLine("{0} {1} {2}", position.Latitude, position.Longitude, distance);
                    await _navigation.PushAsync(new NearestVetSearchResultPage(string.Empty, position.Latitude, position.Longitude, distance));
                }
            }
            else
            {
                if(string.IsNullOrEmpty(SearchPlace))
                {
                    Error = AppResources.SearchPlaceIsEmpty;
                }
                else
                {
                    await _navigation.PushModalAsync(new NearestVetSearchResultPage(SearchPlace, 0, 0, 0));
                }
            }
        }

        private double GetChoosenDistance()
        {
            DistanceToVet dist = (DistanceToVet)Enum.Parse(typeof(DistanceToVet), Distance.ToString());
            switch(dist)
            {
                case DistanceToVet.km1:
                    return 1.0;
                case DistanceToVet.km2:
                    return 2.0;
                case DistanceToVet.km5:
                    return 5.0;
                case DistanceToVet.km10:
                    return 10.0;
                case DistanceToVet.km20:
                    return 20.0;
                case DistanceToVet.km50:
                    return 50.0;
                case DistanceToVet.km100:
                    return 100.0;
                default:
                    return 10.0;
            }
        }
    }
}
