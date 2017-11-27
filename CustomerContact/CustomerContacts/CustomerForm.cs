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
using  CustomerContacts.Interface.Repository;

namespace CustomerContacts
{
    public partial class CustomerForm : Form
    {
        private bool addcontact;
        private int customerid = 0;
        private int _customerId = 0;
        CustomerRepository customerRep = new CustomerRepository();
        ContactRepository contactRep = new ContactRepository();

        public CustomerForm()
        {
            InitializeComponent();
        }

        public bool AddContact
        {
            get
            {
                return addcontact;
            }
            set
            {
              addcontact = value;
            }
        }

        public int CustomerId
        {
            get
            {
                return customerid;
            }
            set
            {
                customerid = value;
            }
        }
        
        private void ClearTextBoxes()
        {
            txtCustormerName.Text = "";
            txtLatitude.Text = "";
            txtLongitude.Text = "";
            txtContactName.Text = "";
            txtContactEmail.Text = "";
            txtContactNumber.Text = "";
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            if (AddContact)
            {
                var Customer = customerRep.GetCustomerById(customerid);

                txtCustormerName.Text = Customer.customer_name;
                txtLatitude.Text = Customer.latitude.ToString();
                txtLongitude.Text = Customer.longitude.ToString();

                if (txtContactName.Text != "")
                {
                    tblContact contact = new tblContact()
                    {
                        contact_name = txtContactName.Text,
                        contact_email = txtContactEmail.Text,
                        contact_number = txtContactNumber.Text,
                        customer_id = customerid
                    };
                    contactRep.AddContact(contact);
                }
               
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!AddContact)
            {
                tblCustomer customer = new tblCustomer()
                {
                    customer_name = txtCustormerName.Text,
                    latitude = Convert.ToDecimal(txtLatitude.Text),
                    longitude = Convert.ToDecimal(txtLongitude.Text)
                };

                int customerId = customerRep.AddCustomer(customer);

                tblContact contact = new tblContact()
                {
                    contact_name = txtContactName.Text,
                    contact_email = txtContactEmail.Text,
                    contact_number = txtContactNumber.Text,
                    customer_id = customerId
                };
                contactRep.AddContact(contact);
                ClearTextBoxes();
            }
            else
            {
                tblContact contact = new tblContact()
                {
                    contact_name = txtContactName.Text,
                    contact_email = txtContactEmail.Text,
                    contact_number = txtContactNumber.Text,
                    customer_id = CustomerId
                };
                contactRep.AddContact(contact);
                ClearTextBoxes();
            }

            CustomerListForm listForm = new CustomerListForm();
            listForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
