using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortwindSchema.Models
{
    public class Order
    {
        public int orderID { get; set; }
        public Customer customer { get; set; }
        public Employee employee { get; set; }
        public Shipper shipper { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime requiredDate { get; set; }
        public DateTime shippedDate { get; set; }
        public string shipVia { get; set; }
        public string freight { get; set; }
        public string shipName { get; set; }
        public string shipAddress { get; set; }
        public string shipCity { get; set; }
        public string shipRegion { get; set; }
        public string shipPostalCode { get; set; }
        public string shipCountry { get; set; }
    }
}
