using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Genre
{
    public class GenreDetail
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name="Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
