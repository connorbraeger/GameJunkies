using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Retailer
{
    public class RetailerDetail
    {
        public int? RetailerId { get; set; }
        public string Name { get; set; }
        [DisplayName("Website Address")]
        public string WebsiteUrl { get; set; }
        [DisplayName("Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
        [DisplayName("Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        [DefaultValue(false), DisplayName("Are there Physical Locations?")]
        public bool HasPhysicalLocations { get; set; }
    }
}
