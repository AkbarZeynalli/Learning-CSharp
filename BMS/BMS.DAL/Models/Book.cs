using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public int PublishYear { get; set; }

        // Relations
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
