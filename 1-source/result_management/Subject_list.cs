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
    public partial class Subject_list : Form
    {
        public Subject_list()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Subject_list_Load(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string sqlcode = "SELECT course_title FROM course";

            MySqlCommand mycom = new MySqlCommand(sqlcode,mycon);

            MySqlDataReader da = mycom.ExecuteReader();

            while (da.Read()) {

                comboBox2.Items.Add(da.GetString(0));

            }
            display();
        }

        public void display() {

            DataTable data1 = new DataTable();
            data1.Columns.Add("Subject ID");
            data1.Columns.Add("Course");
            data1.Columns.Add("Subject Title");
            data1.Columns.Add("Level");
            data1.Columns.Add("duration");


            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "SELECT * FROM subject";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);
            MySqlDataReader d = mycom.ExecuteReader();

            while (d.Read()) {

                data1.Rows.Add(d.GetString(0), d.GetString(1), d.GetString(2), d.GetString(3), d.GetString(4));

            }

            dataGridView1.DataSource = data1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string codes = "SELECT * FROM subject WHERE course_id='" + comboBox2.Text + "'";

            MySqlCommand mycom = new MySqlCommand(codes, mycon);

            MySqlDataReader d = mycom.ExecuteReader();

            string subject_id = "";
            string course_id = "";
            string subject_title = "";
            string level = "";
            string duration = "";

            DataTable td = new DataTable();
            td.Columns.Add("Subject ID");
            td.Columns.Add("Course ID");
            td.Columns.Add("Subject Title");
            td.Columns.Add("Level");
            td.Columns.Add("Duration");

            while (d.Read())
            {


                subject_id = d.GetString(0);
                course_id = d.GetString(1);
                subject_title = d.GetString(2);
                level = d.GetString(3);
                duration = d.GetString(4);

                td.Rows.Add(subject_id, course_id, subject_title, level, duration);


            }


            dataGridView1.DataSource = td;

        }
    }
}
