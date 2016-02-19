using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheLocalVet.Interfaces;
using TheLocalVet.Models;
using Xamarin.Forms;
using Plugin.ExternalMaps;
using TheLocalVet;
using Plugin.Messaging;
using TheLocalVet.Languages;

namespace TheLocalVet.ViewModels
{
    public class NearestVetSingleViewModel : BaseViewModel
    {
        private VetModel _vetModel;

        public RelayCommand CallVetCommand { get; private set; }
        public RelayCommand EmailVetCommand { get; private set; }
        public RelayCommand VisitWebCommand { get; private set; }
        public RelayCommand ViewInMapCommand { get; private set; }
        public RelayCommand CallEmergencyCommand { get; private set; }

        public string Name
        {
            get { return _vetModel.Name; }
            set { _vetModel.Name = value; OnPropertyChanged("Name"); }
        }
        
        public string Address
        {
            get { return _vetModel.Address.ToString(); }
			set { OnPropertyChanged("Address"); OnPropertyChanged ("Zip"); OnPropertyChanged ("AddressStreet"); OnPropertyChanged ("AddressWidth"); }
        }

		public bool IsAddressVisible
		{
			get { return string.IsNullOrEmpty (Address) ? false : true; }
		}

		public string AddressStreet
		{
			get 
			{
				if (!string.IsNullOrEmpty (Address)) 
				{
					var temp = Address.Split (',');
					if (!string.IsNullOrEmpty (temp [0]))
						return temp [0];
					else
						return string.Empty;
				} 
				else 
				{
					return string.Empty;
				}
			}
			set { OnPropertyChanged ("AddressStreet"); }
		}

		public string Zip
		{
			get 
			{
				if (!string.IsNullOrEmpty (Address)) 
				{
					var temp = Address.Split (',');
					if (!string.IsNullOrEmpty (temp [1]))
						return string.Format("{0} ",temp [1].Substring(1));
					else
						return string.Empty;
				} 
				else 
				{
					return string.Empty;
				}
			}
			set { OnPropertyChanged ("Zip"); OnPropertyChanged ("AddressWidth"); }
		}

		public string AddressWidth
		{
			get 
			{ 
				return (Zip.Length * 2).ToString ();
			}
			set { OnPropertyChanged ("AddressWidth"); }
		}

        public string HomeVisit
        {
            get { return _vetModel.HomeVisit ? AppResources.HomeVisit : AppResources.NoHomeVisit; }
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

		public bool IsMapVisible
		{
			get 
			{
				if (_vetModel.Address.Latitude != 0.0 && _vetModel.Address.Longitude != 0.0)
					return true;
				else
					return false;
			}
			set { OnPropertyChanged ("IsMapVisible"); }
		}

		public bool IsEmailWebSitePhoneVisible
		{
			get 
			{
				if (!string.IsNullOrEmpty (Email) || !string.IsNullOrEmpty (Address) || !string.IsNullOrEmpty (Website))
					return true;
				else
					return false;
			}
		}

        public string Email
        {
            get { return _vetModel.Email; }
            set { OnPropertyChanged("Email"); ChangeVisibility(); }
        }

		public bool IsEmailVisible
		{
			get { return string.IsNullOrEmpty (Email) ? false : true; }
		}

        public string Website
        {
            get
            {
                if (!string.IsNullOrEmpty(_vetModel.WebSite))
                    return string.Format("{0}", _vetModel.WebSite.Substring(7));
                else
                    return string.Empty;
            }
            set { OnPropertyChanged("Website"); ChangeVisibility(); }
        }

		public bool IsWebsiteVisible
		{
			get { return string.IsNullOrEmpty (Website) ? false : true; }
		}

        public string Phone
        {
            get { return ParsePhone(_vetModel.Phone); }
            set { OnPropertyChanged("Phone"); ChangeVisibility(); }
        }

        public string OpeningHours
        {
            get { return ParseOpeningHours(_vetModel.OpeningHours); }
            set { OnPropertyChanged("OpeningHours"); }
        }

        public string EmergencyService
        {
            get { return _vetModel.EmergencyService ? AppResources.EmergencyService : AppResources.NoEmergencyService; }
            set { OnPropertyChanged("EmergencyService"); }
        }

        public string EmergencyPhone
        {
            get { return _vetModel.EmergencyPhone; }
            set { OnPropertyChanged("EmergencyPhone"); }
        }

        public bool IsEmergencyVisible
        {
            get { return _vetModel.EmergencyService ? true : false; }
        }

        public NearestVetSingleViewModel(VetModel vetModel)
        {
            _vetModel = vetModel;

            CallVetCommand = new RelayCommand(CallVet);

			if(!string.IsNullOrEmpty(Phone))
				CallVetCommand.IsEnabled = true;
			
            EmailVetCommand = new RelayCommand(EmailVet);

			if(!string.IsNullOrEmpty(Email))
				EmailVetCommand.IsEnabled = true;
			
            VisitWebCommand = new RelayCommand(VisitWeb);

			if(!string.IsNullOrEmpty(Website))
				VisitWebCommand.IsEnabled = true;
			
            ViewInMapCommand = new RelayCommand(ViewInMap);

			if(!string.IsNullOrEmpty(Address))
				ViewInMapCommand.IsEnabled = true;

            CallEmergencyCommand = new RelayCommand(CallEmergency);

            if (!string.IsNullOrEmpty(EmergencyPhone))
                CallEmergencyCommand.IsEnabled = true;
        }

        private void ViewInMap()
        {
			if(!string.IsNullOrEmpty(Address))
				Plugin.ExternalMaps.CrossExternalMaps.Current.NavigateTo(Name, _vetModel.Address.Latitude, _vetModel.Address.Longitude);
        }

        private void VisitWeb()
        {
            //Debug.WriteLine("{0} - {1}", Website, new Uri(Website));
			if(!string.IsNullOrEmpty(_vetModel.WebSite))
				Device.OpenUri(new Uri(_vetModel.WebSite));
        }

        private void ChangeVisibility()
        {
            OnPropertyChanged("IsWebsiteVisible");
            OnPropertyChanged("IsEmailVisible");
            OnPropertyChanged("IsMapVisible");
            OnPropertyChanged("IsEmailWebSitePhoneVisible");
            OnPropertyChanged("IsWebsiteVisible");
            OnPropertyChanged("IsEmergencyVisible");
        }

        private void EmailVet()
        {
            Debug.WriteLine(Email);

			if (!string.IsNullOrEmpty (Email)) 
			{
				//var emailTask = MessagingPlugin.EmailMessenger;
				if (MessagingPlugin.EmailMessenger.CanSendEmail)
					MessagingPlugin.EmailMessenger.SendEmail (new EmailMessageBuilder ().To (Email).Build ());
			}
        }

        private void CallVet()
        {
            Debug.WriteLine("calling {0}", Phone);

			if (!string.IsNullOrEmpty (Phone)) 
			{
				//var phoneCallTask = MessagingPlugin.PhoneDialer;
				if (MessagingPlugin.PhoneDialer.CanMakePhoneCall)
					MessagingPlugin.PhoneDialer.MakePhoneCall (Phone, Name);
			}
        }
        private void CallEmergency()
        {
            Debug.WriteLine("calling {0}", EmergencyPhone);

            if (!string.IsNullOrEmpty(EmergencyPhone))
            {
                //var phoneCallTask = MessagingPlugin.PhoneDialer;
                if (MessagingPlugin.PhoneDialer.CanMakePhoneCall)
                    MessagingPlugin.PhoneDialer.MakePhoneCall(EmergencyPhone, Name);
            }
        }

        private string ParseOpeningHours(List<string> openingHours)
        {
            string returnData = string.Empty;

            foreach(var openingHour in openingHours)
            {
                returnData += string.Format("{0} {1}", openingHour, Environment.NewLine);
            }

            return returnData;
        }

        private string ParsePhone(List<string> phones)
        {
            string returnData = string.Empty;

            if(phones.Count == 0)
            {
                returnData = string.Empty;
            }
            else
            {
                returnData = phones.First();
            }

            return returnData;
        }
    }
}
