using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Interfaces;
using TheLocalVet.Models;
using Xamarin.Forms;

namespace TheLocalVet.ViewModels
{
    public class NearestVetSearchResultViewModel : BaseViewModel
    {
        private IParseHelper _parseHelper;

        private List<VetModel> _vets = new List<VetModel>();

        public List<VetModel> Vets
        {
            get { return _vets; }
            set { _vets = value;  OnPropertyChanged("Vets"); }
        }

        public NearestVetSearchResultViewModel()
        {
            _parseHelper = DependencyService.Get<IParseHelper>();
        }

        public async Task GetNearestVet()
        {
            Vets = await _parseHelper.SearchByPlace("Drammen");
        }
    }
}
