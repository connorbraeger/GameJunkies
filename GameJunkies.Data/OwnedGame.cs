using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameJunkies.Data
{
    public class OwnedGame
    {

        [Key]
        public int? Id { get; set; }
        [ForeignKey(nameof(Game))]
        public int? GameId { get; set; }
        public virtual Console Console { get; set; }
        [ForeignKey(nameof(GamerInfo))]
        public int? GameInfoId { get; set; }
        public virtual GamerInfo GamerInfo { get; set; }
        [Required, DisplayName("Date added to Game Collection")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}