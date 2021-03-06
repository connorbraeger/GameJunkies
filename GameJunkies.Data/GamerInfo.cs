using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Data
{
    public class GamerInfo
    {
        [Key]
        public int? Id { get; set; }
        [Required, Display(Name="Gamertag")]
        [DefaultValue("")]
        public string GamerTag { get; set; }
       // [ForeignKey(nameof(Gamer))]
       // public string GamerId { get; set; }
       // public virtual Gamer Gamer { get; set; }
        public virtual ICollection<OwnedGame> OwnedGames { get; set; }
        public virtual ICollection<OwnedConsole> OwnedConsoles { get; set; }
        [Required, Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
