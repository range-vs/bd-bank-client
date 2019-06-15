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
    public partial class Contract : Form
    {
        public Contract()
        {
            InitializeComponent();
        }

        private void ContractBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.contractBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bank_LoansDataSet);

        }

        private void Contract_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bank_LoansDataSet.contract' table. You can move, or remove it, as needed.
            this.contractTableAdapter.Fill(this.bank_LoansDataSet.contract);

        }
    }
}
