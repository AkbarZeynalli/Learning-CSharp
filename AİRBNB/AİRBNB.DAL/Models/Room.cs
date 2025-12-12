using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AİRBNB.DAL.Models
{
    public class Room : BaseEntity
    {
        public string Title { get; set; }       // Məs: "Sea View Apartment"
        public string Description { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public int MaxGuests { get; set; }

        // Location
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
