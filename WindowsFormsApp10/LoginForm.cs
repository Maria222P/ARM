using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\nikit\source\repos\WindowsFormsApp10\WindowsFormsApp10\Database31.mdb");
            OleDbDataAdapter ada = new OleDbDataAdapter("Select * From Vhod where Login = '" + textBox1.Text + "'and Pass = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string ID = dt.Rows[0][0].ToString();
                string Admin = dt.Rows[0][2].ToString();


                MessageBox.Show($"Добро пожаловать, {ID}");
                this.Hide();
                if (Admin == "true")
                {
                    Form1 ss = new Form1(true);
                    ss.Show();
                }
                else
                {
                    Form1 ss = new Form1(false);
                    ss.Show();
                }
                
                
                con.Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!!!");
            }
        }
    }
}
