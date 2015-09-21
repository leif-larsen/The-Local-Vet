using System.Collections.Generic;
using System.Threading.Tasks;
using TheLocalVet.Models;

namespace TheLocalVet.Interfaces
{
	public interface IParseHelper
	{
		Task<List<VetModel>> SearchByGeoLocation();
		Task<List<VetModel>> SearchByPlace();
        Task<List<EmergencyVetModel>> SearchEmergencyByGeoLocation();
        Task<List<EmergencyVetModel>> SearchEmergencyByPlace();
	}
}