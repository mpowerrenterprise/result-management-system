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
using MySql.Data.MySqlClient;

namespace result_management
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
        }

        private void Results_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Add("Pass");
            comboBox3.Items.Add("Merit");
            comboBox3.Items.Add("Distinction");

            loadStudent();
        }

        public void loadStudent() {

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string code = "SELECT student_id FROM student";

            MySqlCommand mycom = new MySqlCommand(code, mycon);

            MySqlDataReader data = mycom.ExecuteReader();

            while (data.Read()) {

                comboBox1.Items.Add(data.GetString(0));

            }

            dataSet();

        }

        public void dataSet() {

            DataTable t = new DataTable();
            t.Columns.Add("Student ID");
            t.Columns.Add("Student Name");
            t.Columns.Add("Course");
            t.Columns.Add("Subject");
            t.Columns.Add("Result");

            MySqlConnection myconnection = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            myconnection.Open();

            string sqlcoce = "SELECT * FROM results";

            MySqlCommand myCom = new MySqlCommand(sqlcoce, myconnection);

            MySqlDataReader d = myCom.ExecuteReader();

            while (d.Read()) {


                t.Rows.Add(d.GetString(1), d.GetString(2), d.GetString(3), d.GetString(4), d.GetString(5));


            }

            dataGridView1.DataSource = t;

        }

        string batch = "";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string code = "SELECT first_name,course_id,batch_id FROM student WHERE student_id='"+comboBox1.Text+"'";

            MySqlCommand mycom = new MySqlCommand(code, mycon);

            MySqlDataReader data = mycom.ExecuteReader();

            string name = "";
            string course = "";
            

            while (data.Read())
            {
                name = data.GetString(0);
                course = data.GetString(1);
                batch = data.GetString(2);   
            }

            textBox1.Text = name;
            textBox2.Text = course;
            comboBox2.Items.Clear();
            selectSubjects();
        }

        public void selectSubjects() {

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string code = "SELECT subject_title FROM subject WHERE course_id='"+textBox2.Text+"'";

            MySqlCommand mycom = new MySqlCommand(code, mycon);

            MySqlDataReader data = mycom.ExecuteReader();

        

            while (data.Read())
            {

                comboBox2.Items.Add(data.GetString(0));

            }

        }

        public void cler() {

            comboBox2.SelectedItem = null;
            comboBox1.SelectedItem = null;
            comboBox3.SelectedText = null;
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string inserted = "INSERT INTO results VALUES('','"+comboBox1.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+comboBox2.Text+"','"+comboBox3.Text+"','"+batch+"')";
            
            MySqlCommand mycom = new MySqlCommand(inserted, mycon);
            mycom.ExecuteReader();
            MessageBox.Show("Inserted Successfully");
            dataSet();
            cler();
        }
    }
}
