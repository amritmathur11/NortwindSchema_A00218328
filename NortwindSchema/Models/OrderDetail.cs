using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortwindSchema.Models
{
    public class OrderDetail
    {
        [Key]
        public int orderID { get; set; }
        public Product product { get; set; }
        public float unitPrice { get; set; }
        public float quantity { get; set; }
        public float discount { get; set; }

    }
}
