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
    public partial class subject_manage : Form
    {
        public subject_manage()
        {
            InitializeComponent();
        }

        private void subject_manage_Load(object sender, EventArgs e)
        {
          
            selectData();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string data = "SELECT * FROM subject WHERE subject_id='" + textBox5.Text + "'";
            MySqlCommand mycom =new MySqlCommand(data, mycon);


            MySqlDataReader datas = mycom.ExecuteReader();

            while (datas.Read()) {


                textBox1.Text = datas.GetString(1);
                textBox4.Text = datas.GetString(2);
                textBox3.Text = datas.GetString(3);
                textBox2.Text = datas.GetString(4);

                

            }
            

        }


        public void selectData() {

            DataTable table = new DataTable();
            table.Columns.Add("Subject ID");
            table.Columns.Add("Course ID");
            table.Columns.Add("Subject Title");
            table.Columns.Add("Level");
            table.Columns.Add("Duration");

            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string sqlcode = "SELECT * FROM subject";

            MySqlCommand mycom = new MySqlCommand(sqlcode, mycon);

            MySqlDataReader data = mycom.ExecuteReader();

            while (data.Read()) {

                table.Rows.Add(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4));

            }
            dataGridView1.DataSource = table;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string update = "UPDATE subject SET subject_title='" + textBox4.Text + "',level='" + textBox3.Text + "',duration='" + textBox2.Text + "' WHERE subject_id='" + textBox5.Text + "'";

            MySqlCommand mycom = new MySqlCommand(update, mycon);

            mycom.ExecuteNonQuery();
            selectData();
            clear();
            MessageBox.Show("Update Successfully");

        }

        public void clear() {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();

            string deleteQues = "DELETE FROM subject WHERE subject_id='" + textBox5.Text + "'";

            MySqlCommand mycom = new MySqlCommand(deleteQues, mycon);
            mycom.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully");
            selectData();
            clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
