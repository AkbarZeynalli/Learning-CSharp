using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.DAL.Models
{
    public class Match : BaseEntity
    {
        public DateTime MatchDate { get; set; }
        public string Stadium { get; set; }

        public int HomeClubId { get; set; }
        public Club HomeClub { get; set; }

        public int AwayClubId { get; set; }
        public Club AwayClub { get; set; }

        public List<Goal> Goals { get; set; }
    }
}
