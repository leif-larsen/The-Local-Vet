using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Helpers;
using TheLocalVet.Interfaces;
using TheLocalVet.Languages;
using TheLocalVet.Models;
using Xamarin.Forms;

namespace TheLocalVet.ViewModels
{
    public class NearestVetSearchResultViewModel : BaseViewModel
    {
        private IParseHelper _parseHelper;

        private List<VetModel> _vets = new List<VetModel>();
        private string _place;
        private double _latitude;
        private double _longitude;
        private double _distance;

        public event EventHandler<EventArgs> OnSearchForVetFailed;

        public List<VetModel> Vets
        {
            get { return _vets; }
            set { _vets = value;  OnPropertyChanged("Vets"); }
        }

        public NearestVetSearchResultViewModel(string place, double latitude = 0.0, double longitude = 0.0, double distance = 0.0)
        {
            _parseHelper = DependencyService.Get<IParseHelper>();
            _place = place;
            _latitude = latitude;
            _longitude = longitude;
            _distance = distance;
        }

        public async Task GetNearestVet()
        {
            using (UserDialogs.Instance.Loading(AppResources.Loading))
            { 
                if (!string.IsNullOrEmpty(_place))
                    Vets = await _parseHelper.SearchByPlace(MiscFunctions.UpperCaseFirst(_place));
                else
                    Vets = await _parseHelper.SearchByGeoLocation(_latitude, _longitude, _distance);
            }

            if (Vets.Count == 0)
            {
                await UserDialogs.Instance.AlertAsync(AppResources.FailedToFindVet, AppResources.Error, "OK");

                if (OnSearchForVetFailed != null)
                    OnSearchForVetFailed(this, new EventArgs());
            }
        }
    }
}
