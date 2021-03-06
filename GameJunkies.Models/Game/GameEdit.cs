using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Game
{
    public class GameEdit
    {
        public int? GameId { get; set; }
     
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ParentalRating { get; set; }
        [Required]
        public int? GenreId { get; set; }
        [Required]
        public int? DeveloperId { get; set; }
        [Required]
        public int? PublisherId { get; set; }
        [Required]
        public float? Rating { get; set; }
        [Required, Display(Name ="Release Date")]
        public DateTimeOffset ReleaseDate { get; set; }
    }
}
