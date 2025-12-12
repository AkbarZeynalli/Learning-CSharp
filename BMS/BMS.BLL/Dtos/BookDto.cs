using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BLL.Dtos
{
    public record BookDto : BaseDto
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public int PublishYear { get; set; }

        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
