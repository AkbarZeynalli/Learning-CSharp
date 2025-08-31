using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalFootballLeague
{
    internal class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }              // Komandanın şəhəri
        public string Stadium { get; set; }           // Stadion adı    
        public int FoundedYear { get; set; }          // Yarandığı il
        public string Coach { get; set; }


    }
}
