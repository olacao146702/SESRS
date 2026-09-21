using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SESRS.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void btnPrograms_Click(object sender, EventArgs e)
        {
            ProgramManagementForm programForm = new ProgramManagementForm();
            programForm.ShowDialog();
        }
    }
}
