using SESRS.Services;

namespace SESRS.Forms;

public partial class ProgramManagementForm : Form
{
    private readonly ProgramService programService = new();

    public ProgramManagementForm()
    {
        InitializeComponent();

        LoadPrograms();
    }

    private void LoadPrograms()
    {
        try
        {
            var programs = programService.GetAllPrograms();

            MessageBox.Show("Programs found: " + programs.Count);

            dgvPrograms.DataSource = programs;

            dgvPrograms.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPrograms.ReadOnly = true;

            dgvPrograms.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPrograms.MultiSelect = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Unable to load programs.\n\n" + ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}