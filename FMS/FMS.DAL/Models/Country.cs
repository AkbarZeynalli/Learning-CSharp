using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.DAL.Models
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public List<League> Leagues { get; set; }
    }
}
