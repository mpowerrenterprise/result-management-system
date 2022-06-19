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
    public partial class addStudent : Form
    {
        public addStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {

                MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
                mycon.Open();

                string genger = "";

                if (radioButton1.Checked) {

                    genger = "Male";

                } else if (radioButton2.Checked) {

                    genger = "Female";

                }

                string codes = "INSERT INTO student VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+dateTimePicker1.Text+"','"+textBox10.Text+"','"+textBox9.Text+"','"+textBox7.Text+"','"+genger+"','"+textBox8.Text+"','"+textBox6.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"')";


                MySqlCommand mycom = new MySqlCommand(codes, mycon);

                mycom.ExecuteNonQuery();
                MessageBox.Show("Inserted Successfully");
                dataFromDB();
                clear();
                mycon.Close();


            }
            else {



                MessageBox.Show("Please fill all of the details");

            }

        }

        public void clear() {

            textBox1.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox10.Text = "";
           
            radioButton1.Checked = true;


        }

        private void addStudent_Load(object sender, EventArgs e)
        {
            dataFromDB();
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "SELECT course_title FROM course";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);

            MySqlDataReader myData = mycom.ExecuteReader();

            while (myData.Read()) {


                comboBox1.Items.Add(myData.GetString(0));

            }

            mycon.Clone();

           
        }

        public void dataFromDB()
        {

            DataTable table = new DataTable();
            table.Columns.Add("Student ID");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            table.Columns.Add("Date Of Birth");
            table.Columns.Add("Age");
            table.Columns.Add("Email");
            table.Columns.Add("Phone No");
            table.Columns.Add("Gender");
            table.Columns.Add("Address");
            table.Columns.Add("NIC Card No");
            table.Columns.Add("Course");
            table.Columns.Add("Batch_id");

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "SELECT * FROM student";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);

            MySqlDataReader myData = mycom.ExecuteReader();

            while (myData.Read())
            {


                table.Rows.Add(myData.GetString(0), myData.GetString(1), myData.GetString(2), myData.GetString(3), myData.GetString(4), myData.GetString(5), myData.GetString(6), myData.GetString(7), myData.GetString(8), myData.GetString(9), myData.GetString(10), myData.GetString(11));


            }

            dataGridView1.DataSource = table;

            mycon.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            MySqlConnection mycon2 = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon2.Open();

            string codes2 = "SELECT batch_no FROM batch WHERE course_id='" + comboBox1.Text + "'";


            MySqlCommand mycom2 = new MySqlCommand(codes2, mycon2);

            MySqlDataReader mydata2 = mycom2.ExecuteReader();

            while (mydata2.Read())
            {


                comboBox2.Items.Add(mydata2.GetString(0));

            }

            mycon2.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
