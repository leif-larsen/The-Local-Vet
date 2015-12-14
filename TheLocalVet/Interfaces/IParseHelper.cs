using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLocalVet.Models;
using System.Collections.ObjectModel;

namespace TheLocalVet.Interfaces
{
	public interface IParseHelper
	{
        event EventHandler<MessagesEventArgs> OnParseError;
		Task<ObservableCollection<VetModel>> SearchByGeoLocation(double latitude, double longitude, double distance);
		Task<ObservableCollection<VetModel>> SearchByPlace(string placeName);
		Task<ObservableCollection<EmergencyVetModel>> SearchEmergencyByGeoLocation(double latitude, double longitude);
		Task<ObservableCollection<EmergencyVetModel>> SearchEmergencyByPlace(string placeName);
	}
}