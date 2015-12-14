using System;
using Xamarin.Forms;
using TheLocalVet.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using TheLocalVet.Models;
using Parse;
using TheLocalVet.Languages;
using System.Collections.ObjectModel;

[assembly:Dependency(typeof(TheLocalVet.iOS.Helpers.ParseHelper))]
namespace TheLocalVet.iOS.Helpers
{
	public class ParseHelper : IParseHelper
	{
		public event EventHandler<MessagesEventArgs> OnParseError;

		public async Task<ObservableCollection<VetModel>> SearchByGeoLocation(double latitude, double longitude, double distance)
		{
			ObservableCollection<VetModel> vetList = new ObservableCollection<VetModel>();

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
				RaiseOnParseError(new MessagesEventArgs(string.Format("{0} - {1}", AppResources.ParseHelperError, ex.Message)));
			}

			return vetList;
		}

		public async Task<ObservableCollection<VetModel>> SearchByPlace(string placeName)
		{
			ObservableCollection<VetModel> vetList = new ObservableCollection<VetModel>();

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
					RaiseOnParseError(new MessagesEventArgs(string.Format("{0} - {1}", AppResources.ParseHelperError, ex.Message)));
				}
			}
			else
			{
				throw new ArgumentException();
			}

			return vetList;
		}

		public Task<ObservableCollection<EmergencyVetModel>> SearchEmergencyByGeoLocation(double latitude, double longitude)
		{
			throw new NotImplementedException();
		}

		public Task<ObservableCollection<EmergencyVetModel>> SearchEmergencyByPlace(string placeName)
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

			if(vetData.ContainsKey("name"))
				vetModel.Name = vetData.Get<string>("name");

			if (vetData.ContainsKey("email"))
				vetModel.Email = vetData.Get<string>("email");

			if (vetData.ContainsKey("website"))
				vetModel.WebSite = vetData.Get<string>("website");

			if (vetData.ContainsKey("competency"))
				vetModel.MainCompetency = (Competency)Enum.Parse(typeof(Competency), vetData.Get<string>("competency"));

			if (vetData.ContainsKey("homevisit"))
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

			string openingHours = string.Empty;

			if (vetData.ContainsKey("openingHours"))
				openingHours = vetData.Get<string>("openinghours");

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

			string expertise = string.Empty;

			if (vetData.ContainsKey("expertise"))
				expertise = vetData.Get<string>("expertise");

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

			ParseGeoPoint geoPoint = new ParseGeoPoint();

			if (vetData.ContainsKey("geolocation"))
			{
				geoPoint = vetData.Get<ParseGeoPoint>("geolocation");
				address.Latitude = geoPoint.Latitude;
				address.Longitude = geoPoint.Longitude;
			}


			if (vetData.ContainsKey("address"))
				address.Address = vetData.Get<string>("address");

			if (vetData.ContainsKey("address_country"))
				address.Country = vetData.Get<string>("address_country");

			if (vetData.ContainsKey("address_county"))
				address.County = vetData.Get<string>("address_county");

			if (vetData.ContainsKey("address_municipality"))
				address.Municipality = vetData.Get<string>("address_municipality");

			return address;
		}
	}
}

