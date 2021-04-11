using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameJunkies.Data
{
    public class OwnedConsole
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey(nameof(Console))]
        public int? ConsoleId { get; set; }
        public virtual Console Console { get; set; }
        [ForeignKey(nameof(GamerInfo))]
        public int? GameInfoId { get; set; }
        public virtual GamerInfo GamerInfo { get; set; }
        [Required, DisplayName("Date added to Console Collection")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}