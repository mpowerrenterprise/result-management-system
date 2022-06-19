using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace result_management
{
    public partial class waitScreen : Form
    {
        public waitScreen()
        {
            InitializeComponent();
        }

        private void waitScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.ForeColor = Color.Red;
          
        }

        int bar = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int value = bar += 2;

            progressBar1.Value = value;

            if (value == 100) {

                timer1.Stop();
                this.Hide();
                displayFrom ds = new displayFrom();
                ds.Show();

            }
            
        }
       
    }
}
