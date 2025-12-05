using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FMS.DAL.Models
{
    public class Club: BaseEntity
    {
        public string Name { get; set; }
        public DateTime FoundedYear { get; set; }

        public int LeagueId { get; set; }
        public League League { get; set; }

        public List<Player> Players { get; set; }
        public List<Match> HomeMatches { get; set; }
        public List<Match> AwayMatches { get; set; }
    }
}
