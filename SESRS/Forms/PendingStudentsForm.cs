using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class PendingStudentsForm : Form
    {
        private readonly StudentService _studentService = new();

        public PendingStudentsForm()
        {
            InitializeComponent();
        }

        private void PendingStudentsForm_Load(object sender, EventArgs e)
        {
            LoadPendingStudents();
        }

        private void LoadPendingStudents()
        {
            try
            {
                dgvPendingStudents.DataSource =
                    _studentService.GetPendingStudents();

                dgvPendingStudents.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvPendingStudents.ReadOnly = true;
                dgvPendingStudents.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvPendingStudents.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load pending students.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
