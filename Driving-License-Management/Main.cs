using Driving_License_Management.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople form = new frmListPeople();
            form.ShowDialog();
        }
    }
}
