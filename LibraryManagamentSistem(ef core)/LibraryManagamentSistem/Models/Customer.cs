using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagamentSistem.Models
{
    internal class Customer: Person
    {
        public DateTime MembershipDate { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
