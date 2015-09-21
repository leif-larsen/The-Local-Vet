using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLocalVet.Models
{
    public class AddressModel
    {
        public string Place { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string StreetName { get; set; }
        public string Municipality { get; set; }

        public int ZipNr { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public AddressModel()
        {
            Place = string.Empty;
            County = string.Empty;
            Country = string.Empty;
            StreetName = string.Empty;
            Municipality = string.Empty;

            ZipNr = 0000;

            Latitude = 0.0;
            Lonigitude = 0.0;
        }
    }
}
