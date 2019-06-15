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
    public partial class Insurance : Form
    {
        public Insurance()
        {
            InitializeComponent();
        }

        private void InsuranceBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.insuranceBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bank_LoansDataSet);

        }

        private void Insurance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bank_LoansDataSet.insurance' table. You can move, or remove it, as needed.
            this.insuranceTableAdapter.Fill(this.bank_LoansDataSet.insurance);

        }
    }
}
