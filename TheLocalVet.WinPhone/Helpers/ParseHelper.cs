using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parse;
using TheLocalVet.Interfaces;
using TheLocalVet.Models;

[assembly: Xamarin.Forms.Dependency(typeof(TheLocalVet.Interfaces.IParseHelper))]
namespace TheLocalVet.WinPhone.Helpers
{
    public class ParseHelper : IParseHelper
    {
        public Task<List<VetModel>> SearchByGeoLocation()
        {
            throw new NotImplementedException();
        }

        public Task<List<VetModel>> SearchByPlace()
        {
            throw new NotImplementedException();
        }

        public Task<List<EmergencyVetModel>> SearchEmergencyByGeoLocation()
        {
            throw new NotImplementedException();
        }

        public Task<List<EmergencyVetModel>> SearchEmergencyByPlace()
        {
            throw new NotImplementedException();
        }
    }
}
