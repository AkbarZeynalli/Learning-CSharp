using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagamentSistem.Models
{
    internal class Library: BaseEntity
    {

        public string Name { get; set; }
        public string Address { get; set; }
    }
}
