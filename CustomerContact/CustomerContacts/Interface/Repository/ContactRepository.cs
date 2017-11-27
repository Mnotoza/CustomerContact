using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerContacts.Interface.Repository
{
    public class ContactRepository : IContactRepository
    {
        ContactDBEntities1 dbContext = new ContactDBEntities1();
        tblContact _contact = new tblContact();

        public void AddContact(tblContact contact)
        {
            try
            {
                _contact.contact_name = contact.contact_name;
                _contact.contact_email = contact.contact_email;
                _contact.contact_number = contact.contact_number;
                _contact.customer_id = contact.customer_id;
                dbContext.tblContacts.Add(_contact);
                dbContext.SaveChanges();
            }
            catch (Exception exe)
            {
                string message = exe.Message;
            }
        }

        public tblContact GetContactById(int contactId)
        {
            throw new NotImplementedException();
        }

        public List<tblContact> GetContactsByCustomerID(int customerId)
        {
            var lsEmployee = from empl in dbContext.tblContacts
                             join pers in dbContext.tblCustomers on empl.customer_id equals pers.customer_id
                             where empl.customer_id == customerId
                select empl;
            return lsEmployee.ToList();  
           
        }

        public List<tblContact> GetAllContacts()
        {
            throw new NotImplementedException();
        }
    }
}
