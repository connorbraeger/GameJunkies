using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.GamerInfo
{
    public class GamerInfoDetail
    {
        public int? Id { get; set; }
        [DisplayName("Gamertag")]
        public string GamerTag { get; set; }
        public List<string> OwnedConsoles { get; set; } = new List<string>();
        public List<string> OwnedGames { get; set; } = new List<string>();
        [DisplayName("Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [DisplayName("Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
