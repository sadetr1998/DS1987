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

namespace CustomService
{
    public partial class Form2 : Form
    {
        static public Form2 f2 = new Form2();
        string connectionString = @"Data Source=ВАСИЛИЙ-ПК\SQLEXPRESS;Initial Catalog=CustomsService;Integrated Security=True";
        SqlConnection sqlConnection;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string AI;
            sqlConnection = new SqlConnection(connectionString);
            SqlDataAdapter sysDataAdapter = new SqlDataAdapter(@"SELECT Auth_Id FROM Auth WHERE [Log] = '" + Form1.Log + "'", sqlConnection);
            DataTable sysDataTable = new DataTable();
            sysDataAdapter.Fill(sysDataTable);
            if (sysDataTable.Rows[0].ToString() == "1")
            {
                AI = sysDataTable.Rows[0].ToString();
                SqlDataAdapter sysDataAdapter1 = new SqlDataAdapter(@"SELECT (LastName, FirstName, MiddleName) FROM  WHERE Id_Auth = '" + AI + "'", sqlConnection);
                DataTable sysDataTable1 = new DataTable();
                sysDataAdapter1.Fill(sysDataTable1);
                if (sysDataTable1.Rows[0].ToString() == "1")
                {
                    label1.Text = sysDataTable1.Rows[0].ToString();
                }
            }
            else
            {
                MessageBox.Show("Неудалось считать данные, обратитесь к администратору (разработчику)", "Ошибка 0x0001", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Form1.f1.Show();
                this.Close();
            }
        }
    }
}
