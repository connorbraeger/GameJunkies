using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Retailer
{
    public class RetailerListItem
    {
        public int? RetailerId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
