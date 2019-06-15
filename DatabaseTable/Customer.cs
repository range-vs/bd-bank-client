using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursTwoSemestry.DatabaseTable
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void CustomerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bank_LoansDataSet);

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bank_LoansDataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.bank_LoansDataSet.customer);

        }
    }
}
