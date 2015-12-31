using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Interfaces;
using TheLocalVet.Models;
using TheLocalVet.WinPhone.Helpers;
using FakeItEasy;
using Parse;
using System.Collections.ObjectModel;

namespace TheLocalVet.WinPhone.UnitTests
{
    [TestFixture]
    public class ParseHelperTests
    {
        [Test]
        public async void AssertSearchVetByGeoLocationBadCoordinates()
        {
            IParseHelper parseHelper = new ParseHelper();
            ObservableCollection<VetModel> queryResult = await parseHelper.SearchByGeoLocation(180, 340, 10);

            CollectionAssert.IsEmpty(queryResult);
        }

        [Test]
        public async void AssertSearchVetByGeoLocationGoodCoordinates()
        {
            //var parseFake = A.Fake(ParseClient);
            ParseClient.Initialize("eKWSJpWP5VDZV8QKfwVIVKLnjvPxsdhvl2lKI2Dd", "aKV1AIEnUtpuRVco86b6euTdz1e0PANoGmllJ9sD");

            IParseHelper parseHelper = new ParseHelper();
            ObservableCollection<VetModel> queryResult = await parseHelper.SearchByGeoLocation(59.7507026, 10.161479999999983, 10);

            CollectionAssert.IsNotEmpty(queryResult);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public async void AssertSearchVetByPlaceBadPlaceNameFormat()
        {
            IParseHelper parseHelper = new ParseHelper();
            var queryResult = await parseHelper.SearchByPlace(string.Empty);
        }

        [Test]
        public async void AssertSearchVetByPlaceGoodPlaceNameFormat()
        {
            IParseHelper parseHelper = new ParseHelper();
            ObservableCollection<VetModel> queryResult = await parseHelper.SearchByPlace("Drammen");

            CollectionAssert.IsNotEmpty(queryResult);
        }

        [Test]
        public void AssertSearchEmergencyByGeoLocationBadCoordinates()
        {
            IParseHelper parseHelper = new ParseHelper();
        }

        [Test]
        public void AssertSearchEmergencyByGeoLocationGoodCoordinates()
        {
            IParseHelper parseHelper = new ParseHelper();
        }

        [Test]
        public void AssertSearchEmergencyByPlaceBadPlaceNameFormat()
        {
            IParseHelper parseHelper = new ParseHelper();
        }

        [Test]
        public void AssertSearchEmergencyByPlaceGoodPlaceNameFormat()
        {
            IParseHelper parseHelper = new ParseHelper();
        }
    }
}