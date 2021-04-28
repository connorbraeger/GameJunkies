using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameJunkies.Data
{
    public class Developer
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Size of the Company")]
        public string CompanySize { get; set; }
        [Required, Display(Name="Country Company is based out of")]
        public string Country { get; set; }
        [Required, DefaultValue(null)]
        public float? Rating { get; set; }
        public virtual ICollection<Game> Games { get; set; } 
        [Required, Display(Name="Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}