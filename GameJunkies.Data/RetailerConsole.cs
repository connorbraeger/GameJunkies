using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameJunkies.Data
{
    public class RetailerConsole
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey(nameof(Console))]
        public int? ConsoleId { get; set; }
        public virtual Console Console { get; set; }
        [ForeignKey(nameof(Retailer))]
        public int? RetailerId { get; set; }
        public virtual Retailer Retailer { get; set; }
        [Required, DisplayName("Are there any in stock?"),DefaultValue(false)]
        public bool IsInStock { get; set; }
        [Required,DisplayName("Stock Count"),DefaultValue(0)]
        public int NumberInStock { get; set; }

        [Required, DisplayName("Retailer Price")]
        public decimal RetailerPrice { get; set; }
    }
}