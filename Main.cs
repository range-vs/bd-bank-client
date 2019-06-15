using CursMaryTwoSemestry.CombinedDataBase;
using CursTwoSemestry.DatabaseTable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursTwoSemestry
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitMenu();
        }

        private void InitMenu()
        {
            string[] names = new string[] { "Актёры", "Занятость", "Роли", "Звания" };
            for (int i = 0; i < names.Length; i++)
            {
                var elemMenu = new ToolStripMenuItem(names[i])
                {
                    Tag = i
                };
                elemMenu.Click += (sender, e) =>
                {
                    int? k = ((sender as ToolStripMenuItem).Tag as int?);
                    CreateTable(k.Value).ShowDialog();
                };
                MenuAllData.DropDownItems.Add(elemMenu);
            }
            string[] namesCombined = new string[] { "Все клиенты и их кредиты", "Все сотрудники и их договора", "Все страховки и их страхователи" };
            for (int i = 0; i < namesCombined.Length; i++)
            {
                var elemMenu = new ToolStripMenuItem(names[i])
                {
                    Tag = i
                };
                elemMenu.Click += (sender, e) =>
                {
                    int? k = ((sender as ToolStripMenuItem).Tag as int?);
                    CreateUniqueDatabase(k.Value).ShowDialog();
                };
                MenuUniqueQuery.DropDownItems.Add(elemMenu);
            }
        }

        private Form CreateTable(int i)
        {
            List<Form> forms = new List<Form>()
            {
                new Contract(),
                new Credit(),
                new Customer(),
                new Employee(),
                new Insurance()
            };
            try
            {
                return forms[i];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private Form CreateUniqueDatabase(int i)
        {
            string[] query = new string[]
            {
                "SELECT customer.last_name, customer.first_name, customer.second_name, credit.credit_period, credit.date_of_issue, credit.total FROM customer, credit, [contract] WHERE customer.id = [contract].customer_id AND credit.id = [contract].id; ",
                "SELECT employee.last_name, employee.first_name, employee.second_name, employee.position, [contract].date_of_contract,  [contract].type_of_contract FROM employee, [contract] WHERE employee.id = [contract].employee_id",
                "SELECT customer.last_name, customer.first_name, customer.second_name, customer.passport_details, customer.workplace, insurance.coverage, insurance.form_of_insuranse, insurance.insurance_company FROM customer, insurance, employee WHERE customer.id = insurance.id AND insurance.employee_id = employee.id; "
            };
            List<string[]> names = new List<string[]>
            {
                new string[]{"Фамилия", "Имя", "Отчество", "Кредитный период", "Дата выдачи кредита", "Сумма кредита"},
                new string[]{"Фамилия", "Имя", "Отчество", "Должность сотрудника", "Дата договора", "Тип договора"},
                new string[]{"Фамилия", "Имя", "Отчество", "Паспортные данные", "Место работы"}
            };
            try
            {
                return new Request(names[i], query[i]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private void AboutShow(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

    }
}
