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
    public partial class manage_course : Form
    {
        public manage_course()
        {
            InitializeComponent();
        }

        private void manage_course_Load(object sender, EventArgs e)
        {
            MySqlConnection myCon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            myCon.Open();

            string selectCourseName = "SELECT course_title FROM course";

            MySqlCommand myCommand = new MySqlCommand(selectCourseName, myCon);
            MySqlDataReader dataOfCourseName = myCommand.ExecuteReader();

            while (dataOfCourseName.Read()) {

                comboBox2.Items.Add(dataOfCourseName.GetString(0));

            }

            myCon.Close();

            comboBox1.Items.Add("Full-Time");
            comboBox1.Items.Add("Part-Time");

            dataSelect();
        }

        public void dataSelect() {

            DataTable table = new DataTable();
            table.Columns.Add("Course ID");
            table.Columns.Add("Course Title");
            table.Columns.Add("Course Type");
            table.Columns.Add("Course Duration");
            table.Columns.Add("Total Fee");

            MySqlConnection myConnection = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            myConnection.Open();

            string dataQ = "SELECT * FROM course";

            MySqlCommand mycom = new MySqlCommand(dataQ, myConnection);

            MySqlDataReader datas = mycom.ExecuteReader();

            while (datas.Read()) {

                table.Rows.Add(datas.GetString(0), datas.GetString(1), datas.GetString(2), datas.GetString(3),datas.GetString(4));


            }

            dataGridView1.DataSource = table;

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string selectDeatails = "SELECT * FROM course WHERE course_title = '" + comboBox2.Text + "'";

            MySqlCommand myCom = new MySqlCommand(selectDeatails, mycon);

            MySqlDataReader files = myCom.ExecuteReader();

            while (files.Read())
            {

                textBox1.Text = files.GetString(0);
                textBox4.Text = files.GetString(1);
                comboBox1.Text = files.GetString(2);
                textBox2.Text = files.GetString(3);
                textBox3.Text = files.GetString(4);

            }
            
            mycon.Close();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clean();



        }

        public void clean() {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string query1 = "UPDATE course SET course_title='" + textBox4.Text + "',course_type='" + comboBox1.Text + "',duration='" + textBox2.Text + "',total_fee='" + textBox3.Text + "' WHERE course_title='" + comboBox2.Text + "'";

            MySqlCommand myCOm = new MySqlCommand(query1, mycon);

            myCOm.ExecuteNonQuery();
            MessageBox.Show("Updated Successfully.");
            mycon.Close();
            dataSelect();
            clean();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string deleteQuery = "DELETE FROM course WHERE course_title='" + comboBox2.Text + "'";

            MySqlCommand mycom = new MySqlCommand(deleteQuery,mycon);

            mycom.ExecuteNonQuery();
            clean();
            mycon.Close();
            dataSelect();
            MessageBox.Show("Deleted Successfully");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
