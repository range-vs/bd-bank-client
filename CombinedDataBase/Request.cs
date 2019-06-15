using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursMaryTwoSemestry.CombinedDataBase
{
    public partial class Request : Form
    {
        public Request(string [] columns, string query)
        {
            InitializeComponent();
            InitData(columns, query);
        }

        private void InitData(string[] columns, string query)
        {
            using (SqlConnection connection = new SqlConnection(CursTwoSemestry.Properties.Settings.Default["Bank_LoansConnectionString"].ToString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    for (int i = 0; i < columns.Length; i++)
                    {
                        DataGrid.Columns.AddRange(new DataGridViewTextBoxColumn() { HeaderText = columns[i]});
                    }
                    while (reader.Read())
                    {
                        object[] line = new object[columns.Length];
                        for (int i = 0; i < columns.Length; i++)
                        {
                            line[i] = reader.GetValue(i);
                        }
                        DataGrid.Rows.Add(line);
                    }
                }
                reader.Close();
            }
        }

    }
}
