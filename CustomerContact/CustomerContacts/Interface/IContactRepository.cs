using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerContacts.Models;

namespace CustomerContacts.Interface
{
    interface IContactRepository
    {
        void AddContact(tblContact contact);
        tblContact GetContactById(int contactId);
        List<tblContact> GetAllContacts();
        List<tblContact> GetContactsByCustomerID(int customerId);
    }
}
