using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Data
{
    public class Game
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, Display(Name="ESRB Rating")]
        public string ParentalRating { get; set; }
        [ForeignKey(nameof(Genre))]
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        [ForeignKey(nameof(Developer))]
        public int? DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }
        [ForeignKey(nameof(Publisher))]
        public int? PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        [Required, DefaultValue(null)]
        public float? Rating { get; set; }
        [Required, Display(Name = "Release Date")]
        public DateTimeOffset ReleaseDate { get; set; }
        public virtual ICollection<ConsoleGame> ConsoleGames { get; set; }
        public virtual ICollection<OwnedGame> OwnedGames { get; set; }
        public virtual ICollection<RetailerGame> RetailerGames{ get; set; }

        [Required, Display(Name = "Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
