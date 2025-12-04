using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSApp.DAL.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CretedDate { get; set; }
    }
}
