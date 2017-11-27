using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerContacts.Interface;
using CustomerContacts.Models;
using CustomerContacts.Interface.Repository;


namespace CustomerContacts
{
    public partial class CustomerListForm : Form
    {
        CustomerRepository customerRep = new CustomerRepository();
        ContactRepository contactRep = new ContactRepository();

        public CustomerListForm()
        {
            InitializeComponent();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            var Customer = customerRep.GetAllCustomers();

            cmbCustomers.ValueMember = "customer_id";
            cmbCustomers.DisplayMember = "customer_name";
            cmbCustomers.DataSource = Customer;
     
        }

       
        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
               var contact = contactRep.GetContactsByCustomerID(Convert.ToInt32(cmbCustomers.SelectedValue));
                dataGridView1.DataSource = contact;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerForm custfrm = new CustomerForm();
            custfrm.AddContact = true;
            custfrm.CustomerId = Convert.ToInt32(cmbCustomers.SelectedValue);
            custfrm.Show();
        }
       
    }
}
