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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection myConnection = new MySqlConnection("SERVER=localhost;DATABASE=result;USER=root;PASSWORD=");
            myConnection.Open();

            string selectTheUsers = "SELECT * FROM user";

            MySqlCommand myCommand = new MySqlCommand(selectTheUsers, myConnection);

            MySqlDataReader userData= myCommand.ExecuteReader();

            string username = "";
            string password = "";
            while (userData.Read()) {


                username = userData.GetString(1);
                password = userData.GetString(2);
            }

            if (textBox1.Text == username && textBox2.Text == password)
            {

                waitScreen wa = new waitScreen();
                this.Hide();
                wa.Show();
               

            }
            else {


                MessageBox.Show("The username or password wrong");

            }

            myConnection.Close();

        }
    }
}
