using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerContacts.Models;

namespace CustomerContacts.Interface
{
    interface ICustomerRepository
    {
        int AddCustomer(tblCustomer customer);
        tblCustomer GetCustomerById(int customerId);
        List<tblCustomer> GetAllCustomers();
    }
}
