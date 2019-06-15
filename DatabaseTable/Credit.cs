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
    public partial class Credit : Form
    {
        public Credit()
        {
            InitializeComponent();
        }

        private void CreditBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.creditBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bank_LoansDataSet);

        }

        private void Credit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bank_LoansDataSet.credit' table. You can move, or remove it, as needed.
            this.creditTableAdapter.Fill(this.bank_LoansDataSet.credit);

        }
    }
}
