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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        string username = "";
        string password = "";

        private void Settings_Load(object sender, EventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            mycon.Open();
            string select = "SELECT username,password FROM user";

            MySqlCommand mycom = new MySqlCommand(select, mycon);

            MySqlDataReader data = mycom.ExecuteReader();

            while (data.Read()) {


                username = data.GetString(0);
                password = data.GetString(1);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == username)
            {

                string newUsr = textBox2.Text;

                string updateCOde = "UPDATE user SET username='" + newUsr + "'";

                MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
                mycon.Open();
                MySqlCommand mycom = new MySqlCommand(updateCOde, mycon);

                mycom.ExecuteNonQuery();
                MessageBox.Show("The username has been changed sccessfully");
                mycon.Close();

                textBox1.Text = "";
                textBox2.Text = "";

            }
            else {

                MessageBox.Show("The old username is wrong");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == password) {

                string newPAss = textBox4.Text;

                MySqlConnection mycon = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
                mycon.Open();
                string update = "UPDATE user SET password='" + textBox4.Text + "'";
                MySqlCommand mycom = new MySqlCommand(update, mycon);
                mycom.ExecuteNonQuery();
                MessageBox.Show("The password has been sccuessfully changed");
                textBox3.Text = "";
                textBox4.Text = "";

            }else
            {


                MessageBox.Show("The Old password is wrong");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Backup();
            MessageBox.Show("The database backup sccessfully");
        }


        private void Restore()
        {


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Restore The Database";
            ofd.Filter = "SQL Files|*.sql";
            string path = "";

            string canRestore = "no";

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                path = ofd.FileName;
                canRestore = "Yes";

            }

            if (canRestore == "Yes")
            {

                try
                {
                    string cs = @"server=localhost;userid=root;password=";
                    MySqlConnection conn = null;
                    MySqlCommand cmd;
                    
                    string constring = "SERVER=localhost;DATABASE=result;UID=root;PASSWORD=";
                    string file = path;
                    using (MySqlConnection connn = new MySqlConnection(constring))
                    {
                        using (MySqlCommand cmdd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmdd))
                            {
                                cmdd.Connection = connn;
                                connn.Open();
                                mb.ImportFromFile(file);
                                connn.Close();
                            }
                        }
                    }
                    

                }
                catch (Exception)
                {


                }

            }
        }

        private void Backup()
        {
            SaveFileDialog sd = new SaveFileDialog();
            
            sd.FileName = "result.sql";
            string path = "";
            if (sd.ShowDialog() == DialogResult.OK)
            {

                path = sd.FileName;


            }
            try
            {
                string constring = "SERVER=localhost;DATABASE=result;UID=root;PASSWORD=";
                string file = path;
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
                
            }
            catch (Exception)
            {


            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Restore();
            MessageBox.Show("The database restored sccessfully");
        }
    }
}
