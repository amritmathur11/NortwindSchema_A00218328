using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortwindSchema.Models
{
    public class Category
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
        public string picture { get; set; }

    }
}
