using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.DAL.Models
{
    public class Player : BaseEntity
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ShirtNumber { get; set; }

        public int ClubId { get; set; }
        public Club Club { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public List<Goal> Goals { get; set; }
    }
}
