using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AİRBNB.DAL.Models
{
    public class Location : BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
