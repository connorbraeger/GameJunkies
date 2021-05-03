using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.ConsoleGame
{
    public class ConsoleGameCreate
    {
        [Required]
        public int? ConsoleId { get; set; }
        [Required]
        public int? GameId { get; set; }

    }
}
