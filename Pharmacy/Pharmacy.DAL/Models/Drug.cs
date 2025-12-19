using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Models
{
    public class Drug : BaseEntity
    {
        public string Name { get; set; }

        public string Barcode { get; set; }

        public decimal SalePrice { get; set; }

        public DateTime ExpireDate { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
