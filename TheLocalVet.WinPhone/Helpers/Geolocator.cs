using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLocalVet.Interfaces;
using TheLocalVet.Models;
using Windows.Devices.Geolocation;

[assembly: Xamarin.Forms.Dependency(typeof(TheLocalVet.WinPhone.Helpers.Geolocator))]
namespace TheLocalVet.WinPhone.Helpers
{
    public class Geolocator : IGeolocator
    {
        private readonly Windows.Devices.Geolocation.Geolocator _locator;

        public Geolocator()
        {
            _locator = new Windows.Devices.Geolocation.Geolocator();
        }

        public double DesiredAccuracy
        {
            get
            {
                return (_locator.DesiredAccuracy == PositionAccuracy.Default) ? 100 : 10;
            }
            set
            {
                _locator.DesiredAccuracy = (value > 10) ? PositionAccuracy.Default : PositionAccuracy.High;
            }
        }

        public bool IsGeolocationAvailable
        {
            get
            {
                return _locator.LocationStatus != PositionStatus.NotAvailable;
            }
        }

        public bool IsGeolocationEnabled
        {
            get
            {
                return _locator.LocationStatus != PositionStatus.Disabled;
            }
        }

        public async Task<Position> GetPositionAsync(int timeout)
        {
            var position = await _locator.GetGeopositionAsync(TimeSpan.MaxValue, TimeSpan.FromMilliseconds(timeout));
            return position.Coordinate.GetPosition();
        }
    }

    public static class CoordinateExtensions
    {
        public static Position GetPosition(this Geocoordinate geocoordinate)
        {
            return new Position
            {
                Accuracy = geocoordinate.Accuracy,
                Altitude = geocoordinate.Altitude,
                Heading = geocoordinate.Heading,
                Latitude = geocoordinate.Latitude,
                Longitude = geocoordinate.Longitude,
                Speed = geocoordinate.Speed,
                Timestamp = geocoordinate.Timestamp
            };
        }
    }
}
