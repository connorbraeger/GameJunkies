using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameJunkies.Data
{
    public class Genre
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        [Required, DisplayName("Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required, DisplayName("Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}