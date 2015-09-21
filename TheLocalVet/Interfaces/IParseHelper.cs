using System.Collections.Generic;
using System.Threading.Tasks;
using TheLocalVet.Models;

namespace TheLocalVet.Interfaces
{
	public interface IParseHelper
	{
		Task<List<VetModel>> SearchByGeoLocation(double latitude, double longitude);
		Task<List<VetModel>> SearchByPlace(string placeName);
        Task<List<EmergencyVetModel>> SearchEmergencyByGeoLocation(double latitude, double longitutde);
        Task<List<EmergencyVetModel>> SearchEmergencyByPlace(string placeName);
	}
}