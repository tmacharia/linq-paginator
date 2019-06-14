using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Models
{
    public class Location
    {
        public string Street { get; set; }
        [Required]
        public string Town { get; set; }
        public string Area { get; set; }
        [Required]
        public string Country { get; set; }
        public string Tel { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
