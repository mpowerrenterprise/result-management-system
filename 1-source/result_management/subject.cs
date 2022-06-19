using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace result_management
{
    public partial class subject : Form
    {
        public subject()
        {
            InitializeComponent();
        }

        private void subject_Load(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string select = "SELECT course_title FROM course";

            MySqlCommand mycom = new MySqlCommand(select, mycon);
            MySqlDataReader data = mycom.ExecuteReader();

            while (data.Read()) {


                comboBox2.Items.Add(data.GetString(0));

            }

            selectDataFromDb();

        }

        public void selectDataFromDb() {

            MySqlConnection mycon=new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string q = "SELECT * FROM subject";

            DataTable table = new DataTable();
            table.Columns.Add("Subject ID");
            table.Columns.Add("Course");
            table.Columns.Add("Subject Title");
            table.Columns.Add("Level");
            table.Columns.Add("duration");

            MySqlCommand mycom = new MySqlCommand(q, mycon);

            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read()) {


                table.Rows.Add(d.GetString(0), d.GetString(1), d.GetString(2), d.GetString(3), d.GetString(4));
                
            }

            dataGridView1.DataSource = table;

        }

        public void clear() {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.SelectedItem = null;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string ins = "INSERT INTO subject VALUES('','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')";

            MySqlCommand mycom = new MySqlCommand(ins,mycon);

            mycom.ExecuteNonQuery();

            MessageBox.Show("Inserted Successfully");
            selectDataFromDb();
            clear();
        }
    }
}
