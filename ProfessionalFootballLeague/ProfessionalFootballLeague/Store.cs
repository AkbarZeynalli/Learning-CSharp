using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalFootballLeague
{
    internal class Store
    {
        public List<Leauge> LeaugeList = new List<Leauge>();
        public List<Team> TeamList = new List<Team>();
        public List<Player> PlayerList = new List<Player>();
        public Store()
        {
            LeaugeList = new List<Leauge>();
            TeamList = new List<Team>();
            PlayerList = new List<Player>();
        }
    }
}
