using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Console
{
    public class ConsoleListItem
    {
        public int? ConsoleId { get; set; }
        public string Name { get; set; }
        [DisplayName("Made by")]
        public string Brand { get; set; }
        [Display(Name= "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
