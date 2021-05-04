using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.ConsoleGame
{
    public class ConsoleGamesCreates
    {
        [Required]
        public List<ConsoleChoiceItem> ConsoleList { get; set; } = new List<ConsoleChoiceItem>();
        [Required]
        public int? GameId { get; set; }
    }
    public class ConsoleChoiceItem
    {
        public string ConsoleName { get; set; }
        public int? ConsoleId { get; set; }
        public bool isLinked { get; set; } = false;
    }
}
