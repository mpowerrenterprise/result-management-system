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
    public partial class manage_batch : Form
    {
        public manage_batch()
        {
            InitializeComponent();
        }

        private void manage_batch_Load(object sender, EventArgs e)
        {

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "SELECT course_title FROM course";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);

            MySqlDataReader myData = mycom.ExecuteReader();

            while (myData.Read())
            {
                
                comboBox2.Items.Add(myData.GetString(0));


            }
            
            mycon.Close();

            dataFromDB();

        }



        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "UPDATE batch SET start_date='"+dateTimePicker1.Text+"',end_date='"+dateTimePicker2.Text+"' WHERE course_id = '"+comboBox2.Text+"' AND batch_no='"+textBox11.Text+"'";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);

            mycom.ExecuteNonQuery();
            dataFromDB();
            MessageBox.Show("Updated Successfully");
            clear();


        }

        public void dataFromDB()
        {

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

        private void button3_Click(object sender, EventArgs e)
        {

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "DELETE FROM batch WHERE course_id = '" + comboBox2.Text + "' AND batch_no='" + textBox11.Text + "'";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);

            mycom.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully");
            dataFromDB();
            clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        public void clear() {

            textBox1.Text = "";
            textBox11.Text = "";
            textBox2.Text = "";
            comboBox2.SelectedItem = null;

         

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != "")
            {

                MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
                mycon.Open();

                string codes = "SELECT * FROM batch WHERE course_id='"+comboBox2.Text+"' AND batch_no='"+textBox11.Text+"'";

                MySqlCommand mycom = new MySqlCommand(codes, mycon);

                MySqlDataReader myData = mycom.ExecuteReader();

              

                while (myData.Read()) {

                    textBox1.Text = myData.GetString(1);
                    textBox2.Text = myData.GetString(2);
                    dateTimePicker1.Value = myData.GetDateTime(3);
                    dateTimePicker2.Value = myData.GetDateTime(4);
                    
                }

               
            }
            else {

                MessageBox.Show("Please select the above options");

            }

        }
    }
}
