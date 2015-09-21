using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLocalVet.Models
{
    public class EmergencyVetModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public AddressModel Address { get; set; }

        public EmergencyVetModel()
        {
            Name = string.Empty;
            PhoneNumber = string.Empty;
            Address = new AddressModel();
        }
    }
}
