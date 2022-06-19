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
    public partial class add_course : Form
    {
        public add_course()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox2.Text != "")
            {

                MySqlConnection myCon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
                myCon.Open();

                string InsertQuery = "INSERT INTO course VALUES('','" + textBox4.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                MySqlCommand myCom = new MySqlCommand(InsertQuery, myCon);
                myCom.ExecuteNonQuery();

                cleaner();
                SelectionData();

                MessageBox.Show("The course has been successfully created.");
                myCon.Close();
            }
            else {

                MessageBox.Show("Please enter all the values");

            }
            
        }

        private void add_course_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("Part-Time");
            comboBox2.Items.Add("Full-Time");

            SelectionData();



        }

        public void cleaner() {


            comboBox2.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Text = "";

        }

        public void SelectionData() {
            
            DataTable table = new DataTable();
            table.Columns.Add("Course ID");
            table.Columns.Add("Course Title");
            table.Columns.Add("Course Type");
            table.Columns.Add("Duration");
            table.Columns.Add("Total Fee");

            MySqlConnection myCon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            myCon.Open();

            string selectQuery = "SELECT * FROM course";

            MySqlCommand myCom = new MySqlCommand(selectQuery, myCon);

            MySqlDataReader dataCourse = myCom.ExecuteReader();

            while (dataCourse.Read())
            {


                table.Rows.Add(dataCourse.GetString(0), dataCourse.GetString(1), dataCourse.GetString(2), dataCourse.GetString(3), dataCourse.GetString(4));

            }

            dataGridView1.DataSource = table;

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cleaner();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
    }
}
