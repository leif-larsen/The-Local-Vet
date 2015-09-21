using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLocalVet.Models
{
    public class VetModel
    {
        public string Name { get; set; }
        public AddressModel Address { get; set; }
        public List<string> Phone { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public List<string> OpeningHours { get; set; }
        public List<ExpertiseModel> Expertise { get; set; }

        public VetModel()
        {
            Name = string.Empty;
            Address = new AddressModel();
            Phone = new List<string>();
            Email = string.Empty;
            WebSite = string.Empty;
            OpeningHours = new List<string>();
            Expertise = new List<ExpertiseModel>();
        }
    }
}
