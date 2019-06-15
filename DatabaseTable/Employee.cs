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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void EmployeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bank_LoansDataSet);

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bank_LoansDataSet.employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.bank_LoansDataSet.employee);

        }
    }
}
