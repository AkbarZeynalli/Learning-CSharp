using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalFootballLeague
{
    internal class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerSurname { get; set; }
        public int PlayerNumber { get; set; }
        public DateOnly PlayerAge { get; set; }

    }
}
