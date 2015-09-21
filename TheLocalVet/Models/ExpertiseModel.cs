using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLocalVet.Models
{
    public class ExpertiseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ExpertiseModel()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
