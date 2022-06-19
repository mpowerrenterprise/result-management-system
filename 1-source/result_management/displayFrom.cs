using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace result_management
{
    public partial class displayFrom : Form
    {
        public displayFrom()
        {
            InitializeComponent();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addStudent adstude = new addStudent();
            adstude.MdiParent = this;
            adstude.Show();
            
        }

        private void manageStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manage_student ms = new manage_student();
            ms.MdiParent = this;
            ms.Show();
        }

        private void aDDCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_course ac = new add_course();
            ac.MdiParent = this;
            ac.Show();
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manage_course mc = new manage_course();
            mc.MdiParent = this;
            mc.Show();
        }

        private void createBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_batch ab = new Add_batch();
            ab.MdiParent = this;
            ab.Show();
        }

        private void manageBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manage_batch mb = new manage_batch();
            mb.MdiParent = this;
            mb.Show();
        }

        private void aDDSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subject s = new subject();
            s.MdiParent = this;
            s.Show();
        }

        private void manageSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subject_manage sm = new subject_manage();
            sm.MdiParent = this;
            sm.Show();
        }

        private void showAllSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subject_list sl = new Subject_list();
            sl.MdiParent = this;
            sl.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Results add = new Results();
            add.MdiParent = this;
            add.Show();

        }

        private void manageResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Result mr = new Manage_Result();
            mr.MdiParent = this;
            mr.Show();
        }

        private void displayFrom_Load(object sender, EventArgs e)
        {
            Manage_Result mr = new Manage_Result();
            mr.MdiParent = this;
            mr.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings se = new Settings();
            se.MdiParent = this;
            se.Show();
        }
    }
}
