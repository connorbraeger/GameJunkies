using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.ConsoleGame
{
    public class ConsoleListItem
    {
        public int? ConsoleId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Made by")]
        public string Brand { get; set; }
        [Display(Name = "Is Linked to Game")]
        public bool IsLinked { get; set; }
    }
}
