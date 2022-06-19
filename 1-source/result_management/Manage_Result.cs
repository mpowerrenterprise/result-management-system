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
    public partial class Manage_Result : Form
    {
        public Manage_Result()
        {
            InitializeComponent();
        }

        private void Manage_Result_Load(object sender, EventArgs e)
        {

            selectData();
            getCourse();
            com7();

        }


        public void com7() {

            comboBox7.Items.Add("Pass");
            comboBox7.Items.Add("Merit");
            comboBox7.Items.Add("Distinction");

        }
        
        

        public void getCourse() {


            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "SELECT course_title FROM course";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);

            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read()) {


                comboBox1.Items.Add(d.GetString(0));
                comboBox6.Items.Add(d.GetString(0));
                comboBox4.Items.Add(d.GetString(0));
                comboBox9.Items.Add(d.GetString(0));

            }


        }

        public void selectData() {

            DataTable t = new DataTable();
            t.Columns.Add("Result_ID");
            t.Columns.Add("Student_ID");
            t.Columns.Add("First Name");
            t.Columns.Add("Course");
            t.Columns.Add("Subject");
            t.Columns.Add("Result");
            
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string select = "SELECT * FROM results";

            MySqlCommand mycom = new MySqlCommand(select, mycon);

            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read()) {

                t.Rows.Add(d.GetString(0), d.GetString(1), d.GetString(2), d.GetString(3), d.GetString(4), d.GetString(5));


            }

            dataGridView1.DataSource = t;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string select = "SELECT batch_no FROM batch WHERE course_id='" + comboBox1.Text + "'";

            MySqlCommand mycom = new MySqlCommand(select, mycon);

            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read()) {


                comboBox2.Items.Add(d.GetString(0));

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string selectionCode = "SELECT student_id FROM results WHERE course_id='" + comboBox1.Text + "' AND batch_id='" + comboBox2.Text + "'";

            MySqlCommand mycom = new MySqlCommand(selectionCode, mycon);

            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read()) {


                comboBox3.Items.Add(d.GetString(0));

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            DataTable t = new DataTable();
            t.Columns.Add("Result ID");
            t.Columns.Add("Student ID");
            t.Columns.Add("First Name");
            t.Columns.Add("Course");
            t.Columns.Add("Subject");
            t.Columns.Add("Result");

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string selectionCode = "SELECT * FROM results WHERE course_id='" + comboBox1.Text + "' AND batch_id='" + comboBox2.Text + "' AND student_id='"+comboBox3.Text+"'";

            MySqlCommand mycom = new MySqlCommand(selectionCode, mycon);

            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read()) {

                t.Rows.Add(d.GetString(0), d.GetString(1), d.GetString(2), d.GetString(3), d.GetString(4), d.GetString(5));

            }

            dataGridView1.DataSource = t;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable table = new DataTable();
            table.Columns.Add("Result ID");
            table.Columns.Add("Student ID");
            table.Columns.Add("Student Name");
            table.Columns.Add("Course");
            table.Columns.Add("Subject");
            table.Columns.Add("Result");

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string code = "SELECT * FROM results WHERE course_id='" + comboBox6.Text + "'";

            MySqlCommand mycom = new MySqlCommand(code, mycon);
            MySqlDataReader data = mycom.ExecuteReader();

            while (data.Read()) {


                table.Rows.Add(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5));


            }

            dataGridView1.DataSource = table;
            

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string select = "SELECT batch_no FROM batch WHERE course_id='" + comboBox4.Text + "'";

            MySqlCommand mycom = new MySqlCommand(select, mycon);

            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read())
            {


                comboBox5.Items.Add(d.GetString(0));

            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable da = new DataTable();

            da.Columns.Add("Result ID");
            da.Columns.Add("Student ID");
            da.Columns.Add("Student Name");
            da.Columns.Add("Course");
            da.Columns.Add("Subject");
            da.Columns.Add("Result");

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string code = "SELECT * FROM results WHERE course_id='" + comboBox4.Text + "' AND batch_id='" + comboBox5.Text + "'";

            MySqlCommand mycom = new MySqlCommand(code, mycon);

            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read()) {


                da.Rows.Add(d.GetString(0), d.GetString(1), d.GetString(2),d.GetString(3),d.GetString(4),d.GetString(5));

            }

            dataGridView1.DataSource = da;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string select = "SELECT batch_no FROM batch WHERE course_id='" + comboBox9.Text + "'";

            MySqlCommand mycom = new MySqlCommand(select, mycon);

            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read())
            {


                comboBox8.Items.Add(d.GetString(0));

            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataTable da = new DataTable();

            da.Columns.Add("Result ID");
            da.Columns.Add("Student ID");
            da.Columns.Add("Student Name");
            da.Columns.Add("Course");
            da.Columns.Add("Subject");
            da.Columns.Add("Result");

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string code = "SELECT * FROM results WHERE course_id='" + comboBox9.Text + "' AND batch_id='" + comboBox8.Text + "' AND result='" + comboBox7.Text + "'";

            MySqlCommand mycom = new MySqlCommand(code, mycon);
            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read()) {

                da.Rows.Add(d.GetString(0), d.GetString(1), d.GetString(2), d.GetString(3), d.GetString(4), d.GetString(5));

            }

            dataGridView1.DataSource = da;

        }
    }
}
