using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Data
{
    public class Console
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, DisplayName("Made by")]
        public string Brand { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required, DefaultValue(null)]
        public float? Rating { get; set; }
        [Required, DisplayName("Release Date")]
        public DateTimeOffset ReleaseDate { get; set; }
        public virtual ICollection<OwnedConsole> OwnedConsoles { get; set; }
        public virtual ICollection<ConsoleGame> ConsoleGames { get; set; }
        public virtual ICollection<RetailerConsole> RetailerConsoles { get; set; }
        [Required, DisplayName("Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required, DisplayName("Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
