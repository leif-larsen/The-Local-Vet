using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLocalVet.Models
{
    public class AddressModel
    {
        public string County { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Municipality { get; set; }
        
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public AddressModel()
        {
            Address = string.Empty;
            County = string.Empty;
            Country = string.Empty;
            Municipality = string.Empty;

            Latitude = 0.0;
            Longitude = 0.0;
        }
    }
}
