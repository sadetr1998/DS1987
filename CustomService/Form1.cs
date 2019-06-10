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
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=ВАСИЛИЙ-ПК\SQLEXPRESS;Initial Catalog=CustomsService;Integrated Security=True";
        SqlConnection sqlConnection;
        static public string Log;
        static public Form1 f1 = new Form1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(@"SELECT COUNT (*) FROM Auth WHERE [Log] = '" + textBox1.Text +"' AND Pass = '" + textBox2.Text + "'", sqlConnection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows[0][0].ToString() == "1")
            {
                Log = textBox1.Text;
                this.Hide();
                Form2.f2.Show();
            }
            else
            {
                MessageBox.Show("Неверен логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
        }
    }
}
