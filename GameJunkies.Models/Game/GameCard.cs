using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Game
{
    public class GameCard
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public double? Rating { get; set; }
        public string CoverURL { get; set; }
    }
}
