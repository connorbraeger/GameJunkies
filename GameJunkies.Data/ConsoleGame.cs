using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameJunkies.Data
{
    public class ConsoleGame
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey(nameof(Console))]
        public int? ConsoleId { get; set; }
        public virtual Console Console  { get; set; }
        [ForeignKey(nameof(Game))]
        public int? GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}