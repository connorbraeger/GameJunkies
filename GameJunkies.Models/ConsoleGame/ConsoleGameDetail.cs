using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.ConsoleGame
{
    public class ConsoleGameDetail
    {
        public int? Id { get; set; }
        public int? ConsoleId { get; set; }
        [Display(Name = "Console Name")]
        public string ConsoleName { get; set; }
        public int? GameId { get; set; }
        [Display(Name = "Game Title")]
        public string GameTitle { get; set; }
    }
}
