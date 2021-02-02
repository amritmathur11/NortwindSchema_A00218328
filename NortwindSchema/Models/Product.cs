using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortwindSchema.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public Category category { get; set; }
        public Supplier supplier { get; set; }
        public float quantityPerLabel { get; set; }
        public float unitPrice { get; set; }
        public float unitsInStock { get; set; }
        public float unitsOnOrder { get; set; }
        public float reorderLevel { get; set; }
        public string discontinues { get; set; }
    }
}
