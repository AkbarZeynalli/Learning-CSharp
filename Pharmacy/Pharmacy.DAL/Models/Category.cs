using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public List<Drug> Drugs { get; set; }
    }
}
