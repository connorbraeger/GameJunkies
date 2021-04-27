using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Console
{
    public class ConsoleDetail
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required, DisplayName("Made by")]
        public string Brand{ get; set; }
        public decimal Price { get; set; }
        public float? Rating { get; set; }
        [Required, DisplayName("Release Date")]
        public DateTimeOffset ReleaseDate { get; set; }
        [Required, DisplayName("Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required, DisplayName("Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
