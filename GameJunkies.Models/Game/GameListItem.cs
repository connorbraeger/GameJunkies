using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models
{
    public class GameListItem
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset Created { get; set; }
    }
}
