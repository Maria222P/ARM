using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        bool admin = false;
        public Form1(bool AdminAccess)
        {
            InitializeComponent();
            admin = AdminAccess;
            
        }
        public string Way = "select * from [Klient]";
        OleDbConnection conn;
        DataTable dt = new DataTable();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:/Users/nikit/source/repos/WindowsFormsApp10/WindowsFormsApp10/Database31.mdb ; Persist Security Info = True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database31DataSet.Zakaz". При необходимости она может быть перемещена или удалена.
            this.zakazTableAdapter.Fill(this.database31DataSet1.Zakaz);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database31DataSet.SportInventar". При необходимости она может быть перемещена или удалена.
            this.sportInventarTableAdapter.Fill(this.database31DataSet1.SportInventar);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database31DataSet.Klient". При необходимости она может быть перемещена или удалена.
            this.klientTableAdapter.Fill(this.database31DataSet1.Klient);

            //conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;" +
            //                           "Data Source=Database31.mdb");

            //klientTableAdapter.Update(database31DataSet1);
            //MessageBox.Show("Данные обновлены!");


            //adapter = new OleDbDataAdapter("SELECT * FROM Klient", conn);
            //new OleDbCommandBuilder(adapter);
            //adapter.Fill(dt);
            //klientDataGridView.Refresh();
            //klientDataGridView.DataSource = dt;





            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(Way, con);
            //DataSet des = new DataSet("Klient");
            //dataAdapter.Fill(des, "Klient");
            //klientDataGridView.DataSource = des.Tables[0].DefaultView;


            //OleDbDataAdapter ada = new OleDbDataAdapter("Select * From Klient", con);
            //DataTable dt = new DataTable("Klient");

            //ada.Fill(dt);

            //klientDataGridView.DataSource = dt;

            //OleDbDataAdapter ada1 = new OleDbDataAdapter("Select * From SportInventar", con);
            //DataTable dt1 = new DataTable("SportInventar");

            //ada1.Fill(dt1);

            //sportInventarDataGridView.DataSource = dt1;

            if (!admin)
            {
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                checkBox1.Visible = false;
                button2.Visible = false;
                button5.Visible = false;

                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                button1.Visible = false;
                button4.Visible = false;

                button13.Visible = false;
            }

            OleDbDataAdapter ada2 = new OleDbDataAdapter("Select * From Predzakaz", con);
            DataTable dt2 = new DataTable("PredZakaz");

            ada2.Fill(dt2);

            dataGridView1.DataSource = dt2;

        }

        

        private void klientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.zakazBindingSource.EndEdit();

            this.zakazTableAdapter.Update(this.database31DataSet1.Zakaz);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            this.klientBindingSource.EndEdit();

            this.klientTableAdapter.Update(this.database31DataSet1.Klient);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.sportInventarBindingSource.EndEdit();

            this.sportInventarTableAdapter.Update(this.database31DataSet1.SportInventar);
        }



       
        private void button1_Click(object sender, EventArgs e)
        {

            OleDbDataAdapter ada = new OleDbDataAdapter("Select * From [Klient]", con);
            DataTable dt = new DataTable("Klient");

            ada.Fill(dt);

            OleDbCommand cmmd = new OleDbCommand("insert into Klient (NomerPasporta, Familiya, PhoneNumber, Adress, Zalog) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);

            con.Open();

            try
            {
                cmmd.ExecuteNonQuery();
                MessageBox.Show("Добавление успешно");

                dt.Clear();

                ada.Fill(dt);



                klientDataGridView.DataSource = null;
                klientDataGridView.DataSource = dt;
                klientDataGridView.Refresh();

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте ID филиала");
                con.Close();
            }

            //string dob = "insert into Klient (NomerPasporta, Familiya, PhoneNumber, Adress, Zalog) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            //OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Database31.mdb ; Persist Security Info = True");
            //con.Open();
            //OleDbCommand mycommand = con.CreateCommand();
            //mycommand.CommandText = dob;
            //mycommand.ExecuteNonQuery();
            //con.Close();

            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(Way, con);
            //DataSet des = new DataSet("Klient");
            //dataAdapter.Fill(des, "Klient");
            //klientDataGridView.DataSource = des.Tables[0].DefaultView;



            //Database31DataSet1.KlientRow newCustomersRow = database31DataSet1.Klient.NewKlientRow();

            //newCustomersRow.NomerPasporta = int.Parse(textBox1.Text);
            //newCustomersRow.Familiya = textBox2.Text;
            //newCustomersRow.PhoneNumber = textBox3.Text;
            //newCustomersRow.Adress = textBox4.Text;
            //newCustomersRow.Zalog = textBox5.Text;

            //database31DataSet1.Klient.Rows.Add(newCustomersRow);
            //database31DataSet1.AcceptChanges();


            //klientTableAdapter.Update(database31DataSet1);





            //Database31DataSet1TableAdapters.KlientTableAdapter klientTableAdapter = new Database31DataSet1TableAdapters.KlientTableAdapter();

            //klientTableAdapter.Insert(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);


            //klientBindingSource.EndEdit();
            //klientTableAdapter.Fill(database31DataSet1.Klient);

            //klientTableAdapter.Update(database31DataSet1.Klient);
            //klientDataGridView.Refresh();




            //OleDbCommand com = new OleDbCommand();
            //DataSet ds = new DataSet();
            //com.Connection = conn;
            //com.CommandText = "Select * from Klient";
            //conn.Open();
            //klientTableAdapter.Adapter.SelectCommand = com;
            //klientTableAdapter.Adapter.Fill(ds);
            //dt = ds.Tables[0];
            //klientDataGridView.DataSource = dt;
            //conn.Close();
            //database31DataSet1.AcceptChanges();


            //try
            //{
            //    string cmdText = "INSERT INTO Klient Values ("
            //        + int.Parse(textBox1.Text) + " , '"
            //        + textBox2.Text + "'  , "
            //        + textBox3.Text + ", '"
            //        + textBox4.Text + ", '"
            //        + textBox4.Text +  "') ";

            //    cmd = new OleDbCommand(cmdText, con);
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter ada = new OleDbDataAdapter("Select * From [SportInventar]", con);
            DataTable dt = new DataTable("SportInventar");

            ada.Fill(dt);
            OleDbCommand cmmd = new OleDbCommand();

            if (checkBox1.Checked)
            {
                cmmd = new OleDbCommand("insert into SportInventar values('" + textBox6.Text + "','" + textBox7.Text + "','" + int.Parse(textBox8.Text) + "','" + int.Parse(textBox9.Text) + "','" + textBox10.Text + "','" + 1 + "')", con);
            }
            else 
            {
                cmmd = new OleDbCommand("insert into SportInventar values('" + textBox6.Text + "','" + textBox7.Text + "','" + int.Parse(textBox8.Text) + "','" + int.Parse(textBox9.Text) + "','" + textBox10.Text + "','" + 0 + "')", con);
            }
            

            con.Open();

  
                cmmd.ExecuteNonQuery();
                MessageBox.Show("Добавление успешно");

                dt.Clear();

                ada.Fill(dt);



                sportInventarDataGridView.DataSource = null;
                sportInventarDataGridView.DataSource = dt;
                sportInventarDataGridView.Refresh();

                con.Close();
            



            //Database31DataSet1.SportInventarRow newCustomersRow = database31DataSet1.SportInventar.NewSportInventarRow();

            //newCustomersRow.NomerPasporta = int.Parse(textBox1.Text);
            //newCustomersRow.Familiya = textBox2.Text;
            //newCustomersRow.PhoneNumber = textBox3.Text;
            //newCustomersRow.Adress = textBox4.Text;
            //newCustomersRow.Zalog = textBox5.Text;

            //database31DataSet1.Klient.Rows.Add(newCustomersRow);
            //database31DataSet1.AcceptChanges();


            //klientTableAdapter.Update(database31DataSet1);

            //Database31DataSet1TableAdapters.SportInventarTableAdapter SportInventarTableAdapter = new Database31DataSet1TableAdapters.SportInventarTableAdapter();

            //SportInventarTableAdapter.Insert(textBox6.Text, textBox7.Text, int.Parse(textBox8.Text), int.Parse(textBox9.Text), textBox10.Text, checkBox1.Checked);


            //sportInventarBindingSource.EndEdit();
            //sportInventarTableAdapter.Fill(database31DataSet1.SportInventar);

            //sportInventarTableAdapter.Update(database31DataSet1.SportInventar);
            //sportInventarDataGridView.Refresh();

            //OleDbCommand com = new OleDbCommand();
            //DataSet ds = new DataSet();
            //com.Connection = conn;
            //com.CommandText = "Select * from SportInventar";
            //conn.Open();
            //sportInventarTableAdapter.Adapter.SelectCommand = com;
            //sportInventarTableAdapter.Adapter.Fill(ds);
            //dt = ds.Tables[0];
            //sportInventarDataGridView.DataSource = dt;
            //conn.Close();
            //database31DataSet1.AcceptChanges();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox14.Text) < 15)
            {
                MessageBox.Show("Время не может быть меньше 15 минут");
            }
            else
            {


                OleDbDataAdapter ada = new OleDbDataAdapter("Select * From [Zakaz]", con);
                DataTable dt = new DataTable("Zakaz");

                ada.Fill(dt);

                OleDbCommand cmmd = new OleDbCommand("insert into Zakaz (ImiaInvent, NomerPassKlienta, KolvoChasovProkata, StoimProkata, Skidka) values('" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "')", con);

                con.Open();

                try
                {
                    cmmd.ExecuteNonQuery();
                    MessageBox.Show("Добавление успешно");

                    dt.Clear();

                    ada.Fill(dt);



                    zakazDataGridView.DataSource = null;
                    zakazDataGridView.DataSource = dt;
                    zakazDataGridView.Refresh();

                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте ID филиала");
                    con.Close();
                }
            }

            //Database31DataSet1TableAdapters.ZakazTableAdapter zakazTableAdapter = new Database31DataSet1TableAdapters.ZakazTableAdapter();

            //zakazTableAdapter.Insert(textBox12.Text, int.Parse(textBox13.Text), int.Parse(textBox14.Text), int.Parse(textBox15.Text), int.Parse(textBox16.Text));


            //zakazBindingSource.EndEdit();
            //zakazTableAdapter.Fill(database31DataSet1.Zakaz);

            //zakazTableAdapter.Update(database31DataSet1.Zakaz);
            //zakazDataGridView.Refresh();

            //OleDbCommand com = new OleDbCommand();
            //DataSet ds = new DataSet();
            //com.Connection = conn;
            //com.CommandText = "Select * from Zakaz";
            //conn.Open();
            //zakazTableAdapter.Adapter.SelectCommand = com;
            //zakazTableAdapter.Adapter.Fill(ds);
            //dt = ds.Tables[0];
            //zakazDataGridView.DataSource = dt;
            //conn.Close();
            //database31DataSet1.AcceptChanges();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter ada = new OleDbDataAdapter("Select * From [Klient]", con);
            int selectedIndex = klientDataGridView.SelectedRows[0].Index;
            int rowID = int.Parse(klientDataGridView[0, selectedIndex].Value.ToString());
            string sql = "DELETE FROM Klient WHERE NomerPasporta =  @RowID";
            OleDbCommand cmmd = new OleDbCommand("DELETE FROM Klient WHERE NomerPasporta = @RowID", con);
            DataTable dt = new DataTable();


            OleDbCommand deleteRecord = new OleDbCommand();
            deleteRecord.Connection = con;
            deleteRecord.CommandType = CommandType.Text;
            deleteRecord.CommandText = sql;

            OleDbParameter RowParameter = new OleDbParameter();
            RowParameter.ParameterName = "@RowID";
            RowParameter.OleDbType = OleDbType.Integer;
            RowParameter.IsNullable = false;
            RowParameter.Value = rowID;

            deleteRecord.Parameters.Add(RowParameter);
            deleteRecord.Connection.Open();
            deleteRecord.ExecuteNonQuery();
            deleteRecord.Connection.Close();

            dt.Clear();
            ada.Fill(dt);
            klientDataGridView.DataSource = null;
            klientDataGridView.DataSource = dt;
            klientDataGridView.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter ada = new OleDbDataAdapter("Select * From [SportInventar]", con);


            OleDbCommand cmmd = new OleDbCommand("DELETE FROM SportInventar WHERE Naim = '" + textBox6.Text + "'", con);
            string sql = "DELETE FROM SportInventar WHERE Naim =  "+ textBox6.Text;
            DataTable dt = new DataTable();


            //OleDbCommand deleteRecord = new OleDbCommand();
            //deleteRecord.Connection = con;
            //deleteRecord.CommandType = CommandType.Text;
            //deleteRecord.CommandText = sql;

            //OleDbParameter RowParameter = new OleDbParameter();
            //RowParameter.ParameterName = "@RowID";
            //RowParameter.OleDbType = OleDbType.Integer;
            //RowParameter.IsNullable = false;
            //RowParameter.Value = rowID;

            //deleteRecord.Parameters.Add(RowParameter);
            cmmd.Connection.Open();
            cmmd.ExecuteNonQuery();
            cmmd.Connection.Close();

            ////ada.DeleteCommand.Parameters.Add("@number", OleDbType.Integer, 30).Value = int.Parse(klientDataGridView.Rows[klientDataGridView.CurrentCellAddress.Y].Cells["Naim"].Value.ToString());
            //int selectedIndex = klientDataGridView.SelectedRows[0].Index;
            //int rowID = Convert.ToInt32(klientDataGridView[0, selectedIndex].Value.ToString());
            //string sql = "DELETE FROM SportInventar WHERE Naim =  @RowID";
            //DataTable dt = new DataTable();


            //OleDbCommand deleteRecord = new OleDbCommand();
            //deleteRecord.Connection = con;
            //deleteRecord.CommandType = CommandType.Text;
            //deleteRecord.CommandText = sql;

            //OleDbParameter RowParameter = new OleDbParameter();
            //RowParameter.ParameterName = "@RowID";
            //RowParameter.OleDbType = OleDbType.Integer;
            //RowParameter.IsNullable = false;
            //RowParameter.Value = rowID;

            //deleteRecord.Parameters.Add(RowParameter);
            //deleteRecord.Connection.Open();
            //deleteRecord.ExecuteNonQuery();
            //deleteRecord.Connection.Close();

            dt.Clear();
            ada.Fill(dt);
            sportInventarDataGridView.DataSource = null;
            sportInventarDataGridView.DataSource = dt;
            sportInventarDataGridView.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter ada = new OleDbDataAdapter("Select * From [Zakaz]", con);
            int selectedIndex = zakazDataGridView.SelectedRows[0].Index;
            int rowID = int.Parse(zakazDataGridView[0, selectedIndex].Value.ToString());
            string sql = "DELETE FROM Zakaz WHERE IdZakaza =  @RowID";
            OleDbCommand cmmd = new OleDbCommand("DELETE FROM Zakaz WHERE IdZakaza = @RowID", con);
            DataTable dt = new DataTable();


            OleDbCommand deleteRecord = new OleDbCommand();
            deleteRecord.Connection = con;
            deleteRecord.CommandType = CommandType.Text;
            deleteRecord.CommandText = sql;

            OleDbParameter RowParameter = new OleDbParameter();
            RowParameter.ParameterName = "@RowID";
            RowParameter.OleDbType = OleDbType.Integer;
            RowParameter.IsNullable = false;
            RowParameter.Value = rowID;

            deleteRecord.Parameters.Add(RowParameter);
            deleteRecord.Connection.Open();
            deleteRecord.ExecuteNonQuery();
            deleteRecord.Connection.Close();

            dt.Clear();
            ada.Fill(dt);
            zakazDataGridView.DataSource = null;
            zakazDataGridView.DataSource = dt;
            zakazDataGridView.Refresh();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < klientDataGridView.RowCount; i++)
            {
                klientDataGridView.Rows[i].Selected = false;
                for (int j = 0; j < klientDataGridView.ColumnCount; j++)
                    if (klientDataGridView.Rows[i].Cells[j].Value != null)
                        if (klientDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            klientDataGridView.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sportInventarDataGridView.RowCount; i++)
            {
                sportInventarDataGridView.Rows[i].Selected = false;
                for (int j = 0; j < sportInventarDataGridView.ColumnCount; j++)
                    if (sportInventarDataGridView.Rows[i].Cells[j].Value != null)
                        if (sportInventarDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox6.Text))
                        {
                            sportInventarDataGridView.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox14.Text) < 15)
            {
                MessageBox.Show("Время не может быть меньше 15");
            }
            else
            {


                con.Open();
                OleDbCommand com = new OleDbCommand(@"update Zakaz set KolvoChasovProkata = '" + textBox14.Text + "' where NomerPassKlienta =" + textBox13.Text + ";", con);
                com.ExecuteNonQuery();
                con.Close();

                OleDbDataAdapter ada = new OleDbDataAdapter("Select * From [Zakaz]", con);
                DataTable dt = new DataTable("Zakaz");

                ada.Fill(dt);



                con.Open();
                dt.Clear();

                ada.Fill(dt);

                zakazDataGridView.DataSource = null;
                zakazDataGridView.DataSource = dt;
                zakazDataGridView.Refresh();

                con.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\nikit\source\repos\WindowsFormsApp10\WindowsFormsApp10\Database31.mdb");
            OleDbDataAdapter ada = new OleDbDataAdapter("Select * From Zakaz", con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            if (dt.Rows.Count > 0)
            {


                int sum = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum += int.Parse(dt.Rows[i][4].ToString());
                }

                using (StreamWriter writer = new StreamWriter("otchet.txt", true))
                {
                    //writer.WriteLine($"Номер паспорта  Время  Наименование инвентаря  Стоимость проката");
                    writer.Write(string.Format("{0,14}", "Номер паспорта")+"  ");
                    writer.Write(string.Format("{0,20}", "Время")+"  ");
                    writer.Write(string.Format("{0,24}", "Наименование инвентаря")+"  ");
                    writer.WriteLine(string.Format("{0,20}", "Стоимость проката")+"  ");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string NomerPass = string.Format("{0,14}",dt.Rows[i][2].ToString());
                        string time = string.Format("{0,20}", dt.Rows[i][3].ToString());
                        string InventName = string.Format("{0,24}", dt.Rows[i][1].ToString());
                        string stoimProkata = string.Format("{0,20}", dt.Rows[i][4].ToString());
                        writer.WriteLine($"{NomerPass}  {time}  {InventName}  {stoimProkata}");
                    }
                    writer.WriteLine("\n" + "Общая сумма = " + sum);
                }

                con.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {



                con.Open();
                OleDbCommand com = new OleDbCommand(@"update Zakaz set StoimProkata = '" + textBox15.Text + "' where NomerPassKlienta =" + textBox13.Text + ";", con);
                com.ExecuteNonQuery();
                con.Close();

                OleDbDataAdapter ada = new OleDbDataAdapter("Select * From [Zakaz]", con);
                DataTable dt = new DataTable("Zakaz");

                ada.Fill(dt);



                con.Open();
                dt.Clear();

                ada.Fill(dt);

                zakazDataGridView.DataSource = null;
                zakazDataGridView.DataSource = dt;
                zakazDataGridView.Refresh();

                con.Close();
            
        }

        
    }
}
