using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Retailer
{
    public class RetailerCreate
    {
        [Required]
        public string Name { get; set; }
        [Required, DisplayName("Website Address")]
        public string WebsiteUrl { get; set; }
        [Required, DefaultValue(false), DisplayName("Are there Physical Locations?")]
        public bool HasPhysicalLocations { get; set; }
    }
}
