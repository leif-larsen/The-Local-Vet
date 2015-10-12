using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLocalVet.Models;

namespace TheLocalVet.Interfaces
{
	public interface IParseHelper
	{
        event EventHandler<MessagesEventArgs> OnParseError;
		Task<List<VetModel>> SearchByGeoLocation(double latitude, double longitude, double distance);
		Task<List<VetModel>> SearchByPlace(string placeName);
        Task<List<EmergencyVetModel>> SearchEmergencyByGeoLocation(double latitude, double longitude);
        Task<List<EmergencyVetModel>> SearchEmergencyByPlace(string placeName);
	}
}