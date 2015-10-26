using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Parse;

using TheLocalVet.Interfaces;
using TheLocalVet.Models;

[assembly: Xamarin.Forms.Dependency(typeof(TheLocalVet.WinPhone.Helpers.ParseHelper))]
namespace TheLocalVet.WinPhone.Helpers
{
    public class ParseHelper : IParseHelper
    {
        public event EventHandler<MessagesEventArgs> OnParseError;
        
        public async Task<List<VetModel>> SearchByGeoLocation(double latitude, double longitude, double distance)
        {
            List<VetModel> vetList = new List<VetModel>();

            try
            { 
                var geoPoint = new ParseGeoPoint(latitude, longitude);

                var query = ParseObject.GetQuery("Vets");
                query = query.WhereWithinDistance("geolocation", geoPoint, ParseGeoDistance.FromKilometers(distance));

                var result = await query.FindAsync();

                foreach(var vetData in result)
                {
                    VetModel vetModel = GetVetData(vetData);

                    vetList.Add(vetModel);
                }
            }
            catch (Exception ex)
            {
                RaiseOnParseError(new MessagesEventArgs(string.Format("Error occured in ParseHelper - {0}", ex.Message)));
            }

            return vetList;
        }

        public async Task<List<VetModel>> SearchByPlace(string placeName)
        {
            List<VetModel> vetList = new List<VetModel>();

            if(!string.IsNullOrEmpty(placeName))
            { 
                try
                {
                    var query = ParseObject.GetQuery("Vets");
                    query = query.WhereEqualTo("address_municipality", placeName);

                    var result = await query.FindAsync();

                    foreach(var vetData in result)
                    {
                        VetModel vetModel = GetVetData(vetData);
                        vetList.Add(vetModel);
                    }
                }
                catch(Exception ex)
                {
                    RaiseOnParseError(new MessagesEventArgs(string.Format("Error occured in ParseHelper - {0}", ex.Message)));
                }
            }
            else
            {
                throw new ArgumentException();
            }

            return vetList;
        }

        public Task<List<EmergencyVetModel>> SearchEmergencyByGeoLocation(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmergencyVetModel>> SearchEmergencyByPlace(string placeName)
        {
            throw new NotImplementedException();
        }

        private void RaiseOnParseError(MessagesEventArgs e)
        {
            if (OnParseError != null)
                OnParseError(this, e);
        }

        private VetModel GetVetData(ParseObject vetData)
        {
            VetModel vetModel = new VetModel();
            vetModel.Name = vetData.Get<string>("name");
            vetModel.Email = vetData.Get<string>("email");
            vetModel.WebSite = vetData.Get<string>("website");
            vetModel.MainCompetency = (Competency)Enum.Parse(typeof(Competency), vetData.Get<string>("competency"));
            vetModel.HomeVisit = vetData.Get<bool>("homevisit");
            vetModel.Address = GetVetAddress(vetData);
            vetModel.Expertise = GetVetExpertise(vetData);
            vetModel.OpeningHours = GetVetOpeningHours(vetData);
            vetModel.Phone = GetVetPhone(vetData);

            return vetModel;
        }

        private List<string> GetVetPhone(ParseObject vetData)
        {
            List<string> phoneList = new List<string>();
            var phones= vetData.Get<string>("phone");
            var phoneArray = phones.Split(';');

            if(phoneArray != null || phoneArray.Length > 0)
            {
                foreach(var nr in phoneArray)
                {
                    phoneList.Add(nr);
                }
            }

            return phoneList;
        }

        private List<string> GetVetOpeningHours(ParseObject vetData)
        {
            List<string> openingHoursList = new List<string>();

            var openingHours = vetData.Get<string>("openinghours");
            var openingHoursArray = openingHours.Split(';');

            if(openingHoursArray != null || openingHoursArray.Length > 0)
            {
                foreach(var hours in openingHoursArray)
                {
                    openingHoursList.Add(hours);
                }
            }

            return openingHoursList;
        }

        private List<ExpertiseModel> GetVetExpertise(ParseObject vetData)
        {
            List<ExpertiseModel> expertiseList = new List<ExpertiseModel>();

            var expertise = vetData.Get<string>("expertise");
            var expertiseArray = expertise.Split(';');

            if(expertiseArray != null && expertiseArray.Length > 0)
            {
                foreach (var expert in expertiseArray)
                {
                    var expertiseModel = new ExpertiseModel();

                    var expertModelData = expert.Split(':');

                    if (!string.IsNullOrEmpty(expertModelData[0]))
                        expertiseModel.Name = expertModelData[0];

                    if (expertModelData.Length > 1)
                    {
                        if (!string.IsNullOrEmpty(expertModelData[1]))
                            expertiseModel.Description = expertModelData[1];
                    }

                    expertiseList.Add(expertiseModel);
                }
            }


            return expertiseList;
        }

        private AddressModel GetVetAddress(ParseObject vetData)
        {
            AddressModel address = new AddressModel();

            var geoPoint = vetData.Get<ParseGeoPoint>("geolocation");

            address.Address = vetData.Get<string>("address");
            address.Country = vetData.Get<string>("address_country");
            address.County = vetData.Get<string>("address_county");
            address.Municipality = vetData.Get<string>("address_municipality");
            address.Latitude = geoPoint.Latitude;
            address.Longitude = geoPoint.Longitude;

            return address;
        }
    }
}
