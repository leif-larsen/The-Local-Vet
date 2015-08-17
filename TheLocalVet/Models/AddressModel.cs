using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLocalVet.Models
{
    public class AddressModel
    {
        public string StreetName { get; set; }
        public string Place { get; set; }
        public string Municipality { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public int ZipNr { get; set; }
    }
}
