using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Developer
{
    public class DeveloperDetail
    {
        public int? DeveloperId { get; set; }
        public string Name { get; set; }
        [DisplayName("Size of the Company")]
        public string CompanySize { get; set; }
        [DisplayName("Country Company is based out of")]
        public string Country { get; set; }
        public float? Rating { get; set; }
        [DisplayName("Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
        [DisplayName("Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
