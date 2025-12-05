using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.DAL.Models
{
    public class Position : BaseEntity
    {
        public string Name { get; set; } 

        public List<Player> Players { get; set; }
    }
}
