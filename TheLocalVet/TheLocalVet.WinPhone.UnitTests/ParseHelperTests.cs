using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Interfaces;
using TheLocalVet.WinPhone.Helpers;

namespace TheLocalVet.WinPhone.UnitTests
{
    [TestFixture]
    public class ParseHelperTests
    {
        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void AssertSearchVetByGeoLocationBadCoordinates()
        {
            IParseHelper parseHelper = new ParseHelper();
            var queryResult = parseHelper.SearchByGeoLocation(180, 340);
        }

        [Test]
        public void AssertSearchVetByGeoLocationGoodCoordinates()
        {
            IParseHelper parseHelper = new ParseHelper();
            var queryResult = parseHelper.SearchByGeoLocation(180, 340);
        }

        [Test]
        public void AssertSearchVetByPlaceBadPlaceNameFormat()
        {
            IParseHelper parseHelper = new ParseHelper();
            var queryResult = parseHelper.SearchByGeoLocation(180, 340);
        }

        [Test]
        public void AssertSearchVetByPlaceGoodPlaceNameFormat()
        {
            IParseHelper parseHelper = new ParseHelper();
            var queryResult = parseHelper.SearchByGeoLocation(180, 340);
        }

        [Test]
        public void AssertSearchEmergencyByGeoLocationBadCoordinates()
        {
            IParseHelper parseHelper = new ParseHelper();
            var queryResult = parseHelper.SearchByGeoLocation(180, 340);
        }

        [Test]
        public void AssertSearchEmergencyByGeoLocationGoodCoordinates()
        {
            IParseHelper parseHelper = new ParseHelper();
            var queryResult = parseHelper.SearchByGeoLocation(180, 340);
        }

        [Test]
        public void AssertSearchEmergencyByPlaceBadPlaceNameFormat()
        {
            IParseHelper parseHelper = new ParseHelper();
            var queryResult = parseHelper.SearchByGeoLocation(180, 340);
        }

        [Test]
        public void AssertSearchEmergencyByPlaceGoodPlaceNameFormat()
        {
            IParseHelper parseHelper = new ParseHelper();
            var queryResult = parseHelper.SearchByGeoLocation(180, 340);
        }
    }
}