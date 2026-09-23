using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly ReportService _reportService = new();

        public ReportsForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        private void btnStudentReport_Click(object sender, EventArgs e)
        {
            LoadReport(_reportService.GetStudentReport());
        }

        private void btnEnrollmentReport_Click(object sender, EventArgs e)
        {
            LoadReport(_reportService.GetEnrollmentReport());
        }

        private void btnProgramReport_Click(object sender, EventArgs e)
        {
            LoadReport(_reportService.GetProgramReport());
        }

        private void LoadReport(DataTable table)
        {
            dgvReports.AutoGenerateColumns = true;
            dgvReports.DataSource = table;

            dgvReports.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvReports.ReadOnly = true;

            dgvReports.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvReports.MultiSelect = false;
        }
    }
}