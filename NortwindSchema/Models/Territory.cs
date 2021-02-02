using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortwindSchema.Models
{
    public class Territory
    {
        public int territoryID { get; set; }
        public string territoryDescription { get; set; }
        public List<Employee> employees { get; set; }
        public Region region { get; set; }
    }
}
