using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerContacts.Models
{
    public class Contact
    {
        public int contact_id { get; set; }
        public string contact_name { get; set; }
        public string contact_email { get; set; }
        public string contact_number { get; set; }
       // public int customer_id { get; set; }
        public virtual tblCustomer tblCustomer { get; set; }

        public IList<Contact> Contacts { get; set; }
    }
}
