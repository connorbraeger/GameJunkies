using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Retailer
{
    public class RetailerEdit
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Display(Name="Website Address")]
        public string WebsiteUrl { get; set; }
        [Required, DefaultValue(false), Display(Name = "Are there Physical Locations?")]
        public bool HasPhysicalLocations { get; set; }
    }
}
