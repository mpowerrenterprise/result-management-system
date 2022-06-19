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
    public partial class Add_batch : Form
    {
        public Add_batch()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Add_batch_Load(object sender, EventArgs e)
        {

            dataFromDB();

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "SELECT course_title FROM course";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);

            MySqlDataReader myData = mycom.ExecuteReader();

            while (myData.Read())
            {

                comboBox1.Items.Add(myData.GetString(0));

            }

            mycon.Close();

        }



        public void dataFromDB() {

            DataTable table = new DataTable();
            table.Columns.Add("Batch ID");
            table.Columns.Add("Batch No");
            table.Columns.Add("Course");
            table.Columns.Add("Start Date");
            table.Columns.Add("End Date");

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "SELECT * FROM batch";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);

            MySqlDataReader myData = mycom.ExecuteReader();

            while (myData.Read())
            {


                table.Rows.Add(myData.GetString(0), myData.GetString(1), myData.GetString(2), myData.GetString(3), myData.GetString(4));


            }

            dataGridView1.DataSource = table;

            mycon.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear() {

            textBox1.Clear();
            comboBox1.SelectedItem = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && comboBox1.Text != "")
            {

                MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
                mycon.Open();

                string codes = "INSERT INTO batch VALUES('','"+textBox1.Text+"','"+comboBox1.Text+"','"+dateTimePicker1.Text.ToString()+"','"+dateTimePicker2.Text.ToString()+"')";
                
                MySqlCommand mycom = new MySqlCommand(codes, mycon);

                mycom.ExecuteNonQuery();
                dataFromDB();
                MessageBox.Show("Data Inserted Successfully");
                
                clear();
                mycon.Close();

            }
            else {


                MessageBox.Show("Please Enter all details");

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = comboBox1.Text;

            MySqlConnection myCon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            myCon.Open();

            string Codes = "SELECT COUNT(*) FROM batch WHERE course_id='" + comboBox1.Text + "'";

            MySqlCommand mycom = new MySqlCommand(Codes, myCon);

            MySqlDataReader da = mycom.ExecuteReader();

            int num = 1;

            while (da.Read()) {

                num = da.GetInt32(0);
                
            }

            if (comboBox1.SelectedItem != null)
            {

                textBox1.Text = (num + 1).ToString();
            }
        }
    }
}
