using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagamentSistem.Models
{
    internal class Book:BaseEntity
    {

        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
