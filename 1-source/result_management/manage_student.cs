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
    public partial class manage_student : Form
    {
        public manage_student()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void manage_student_Load(object sender, EventArgs e)
        {
            dataFromDB();
        }
        public void clear()
        {

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
            textBox11.Text = "";
            radioButton1.Checked = true;


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

        private void button4_Click(object sender, EventArgs e)
        {

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "SELECT * FROM student";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);

            MySqlDataReader myData = mycom.ExecuteReader();

            string gender = "";

            while (myData.Read()) {

                textBox1.Text = myData.GetString(0);
                textBox2.Text = myData.GetString(1);
                textBox3.Text = myData.GetString(2);
                dateTimePicker1.Value = myData.GetDateTime(3);
                textBox10.Text = myData.GetString(4);
                textBox9.Text = myData.GetString(5);
                textBox7.Text = myData.GetString(6);
                gender = myData.GetString(7);
                textBox8.Text = myData.GetString(8);
                textBox6.Text = myData.GetString(9);
                comboBox1.Text = myData.GetString(10);
                comboBox2.Text = myData.GetString(11);



            }

            if (gender == "Male")
            {


                radioButton1.Checked=true;

            }
            else if(gender=="Female") {

                radioButton2.Checked = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string gender = "";

            if (radioButton1.Checked) {

                gender = "Male";
            }
            else if(radioButton2.Checked){

                gender = "Female";
            }

            string updateQuery = "UPDATE student SET first_name='" + textBox1.Text + "',last_name='" + textBox2.Text + "',date_of_birth='" + dateTimePicker1.Text + "',age='" + textBox10.Text + "',email='" + textBox9.Text + "',phone_number='" + textBox7.Text + "',gender='" + gender + "',address='" + textBox8.Text + "',nic_card_no='" + textBox6.Text + "',course_id='" + comboBox1.Text + "',batch_id='" + comboBox2.Text + "'";

            MySqlCommand mycom = new MySqlCommand(updateQuery,mycon);
            mycom.ExecuteNonQuery();
            dataFromDB();
            clear();
            MessageBox.Show("Updated Successfully");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string deleteCode = "DELETE FROM student WHERE student_id='" + textBox11.Text + "'";
            MySqlCommand mycom = new MySqlCommand(deleteCode,mycon);
            mycom.ExecuteNonQuery();
            clear();
            dataFromDB();
            MessageBox.Show("Deleted Successfully");
            
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 10) {

                

            }
        }
    }
}
