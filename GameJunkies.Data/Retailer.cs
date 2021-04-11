﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Data
{
    public class Retailer
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required,DisplayName("Website Address")]
        public string WebsiteUrl { get; set; }
        [Required, DefaultValue(false), DisplayName("Are there Physical Locations?")]
        public bool HasPhysicalLocations { get; set; }
        public virtual ICollection<RetailerGame> RetailerGames { get; set; }
        public virtual ICollection<RetailerConsole> RetailerConsoles { get; set; }
        [Required, DisplayName("Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required, DisplayName("Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
