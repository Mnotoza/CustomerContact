using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerContacts
{
    public partial class MainForm : Form
    {
        private int customerid = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerListForm listForm = new CustomerListForm();
            listForm.Show();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm _customer = new CustomerForm();
            _customer.Show();
        }
    }
}
