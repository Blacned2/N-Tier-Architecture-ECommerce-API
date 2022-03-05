using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
    }
}
