using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerContacts.Models;
using CustomerContacts;


namespace CustomerContacts.Interface.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
         ContactDBEntities1 dbContext = new ContactDBEntities1();
        tblCustomer _customer = new tblCustomer();
        private int custId = 0;

        public int AddCustomer(tblCustomer customer)
        {
            
            try
            {
                _customer.customer_name = customer.customer_name;
                _customer.latitude = customer.latitude;
                _customer.longitude = customer.longitude;
                dbContext.tblCustomers.Add(_customer);
                dbContext.SaveChanges();

                custId = _customer.customer_id;
            }
            catch (Exception exe)
            {
                string message = exe.Message;
            }
            return custId;
        }

        public tblCustomer GetCustomerById(int customerId)
        {
            var customer = from empl in dbContext.tblCustomers
                           where empl.customer_id == customerId
                select empl;
            return customer.FirstOrDefault();
        }

        public List<tblCustomer> GetAllCustomers()
        {
            List<tblCustomer> employeelst = new List<tblCustomer>();

            var lsCustomers = from customerList in dbContext.tblCustomers
                              select customerList;
            return lsCustomers.ToList(); 
        }
    }
}
