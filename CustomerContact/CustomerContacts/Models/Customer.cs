using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerContacts.Models
{
    public class Customer
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public Nullable<decimal> longitude { get; set; }
    }
}
