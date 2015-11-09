using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Languages;
using TheLocalVet.Models;

namespace TheLocalVet.ViewModels
{
    public class NearestVetSingleViewModel : BaseViewModel
    {
        private VetModel _vetModel;

        public string Name
        {
            get { return _vetModel.Name; }
            set { _vetModel.Name = value; OnPropertyChanged("Name"); }
        }
        
        public string Address
        {
            get { return _vetModel.Address.ToString(); }
            set { OnPropertyChanged("Address"); }
        }

        public string HomeVisit
        {
            get
            {
                if (_vetModel.HomeVisit)
                    return AppResources.Yes;
                else
                    return AppResources.No;
            }
            set { OnPropertyChanged("HomeVisit"); }
        }

        public string CompetencyString
        {
            get
            {
                if (_vetModel.MainCompetency == Competency.bigvet)
                    return AppResources.bigvet;
                else
                    return AppResources.smallvet;
            }
            set { OnPropertyChanged("CompetencyString"); }
        }

        public string Email
        {
            get { return _vetModel.Email; }
            set { OnPropertyChanged("Email"); }
        }

        public string Website
        {
            get { return _vetModel.WebSite; }
            set { OnPropertyChanged("Website"); }
        }



        public NearestVetSingleViewModel(VetModel vetModel)
        {
            _vetModel = vetModel;
        }
    }
}
