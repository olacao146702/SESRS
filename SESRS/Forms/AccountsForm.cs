using System.Data;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Administrator (staff) accounts, plus unlocking any account after repeated wrong passwords.</summary>
public partial class AccountsForm : Form
{
    private readonly UserAdminService _service = new();
    private readonly ListGrid _list;
    private bool _ready;

    public AccountsForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "No accounts match this filter."
        };
    }

    private void AccountsForm_Load(object? sender, EventArgs e)
    {
        cmbRole.SelectedIndex = 0;
        _ready = true;
        ReloadData();
    }

    private void cmbRole_SelectedIndexChanged(object? sender, EventArgs e) { if (_ready) ReloadData(); }

    private void ReloadData()
    {
        _list.Run(() =>
        {
            DataTable table = _service.GetUsers();
            string role = cmbRole.SelectedItem?.ToString() ?? "All";

            if (role != "All")
            {
                DataView view = table.DefaultView;
                view.RowFilter = $"role = '{role}'";
                table = view.ToTable();
            }

            _list.SetData(table, "user_id");
        });
    }

    private void btnNew_Click(object? sender, EventArgs e) => _list.Run(NewAdministrator);
    private void btnToggle_Click(object? sender, EventArgs e) => _list.Run(Toggle);
    private void btnReset_Click(object? sender, EventArgs e) => _list.Run(Reset);
    private void btnUnlock_Click(object? sender, EventArgs e) => _list.Run(Unlock);
    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("accounts"));

    private void NewAdministrator()
    {
        using var dialog = new NewAdministratorDialog();

        if (dialog.ShowDialog(this) == DialogResult.OK && dialog.Credentials != null)
        {
            IssuedCredentials c = dialog.Credentials;

            using var shown = new CredentialsForm("Administrator Created", c.FullName, c.Username, c.TemporaryPassword);
            shown.ShowDialog(this);
            ReloadData();
        }
    }

    private void Toggle()
    {
        DataRow? row = _list.RequireRow("account");

        if (row == null)
        {
            return;
        }

        bool active = Convert.ToString(row["status"]) == "Active";

        if (!_list.Confirm($"{(active ? "Deactivate" : "Activate")} {row["username"]}?"))
        {
            return;
        }

        _service.SetAdministratorActive(Convert.ToInt32(row["user_id"]), !active);
        _list.Success("Account updated.");
        ReloadData();
    }

    private void Reset()
    {
        DataRow? row = _list.RequireRow("account");

        if (row == null)
        {
            return;
        }

        if (!_list.Confirm($"Reset the password of {row["username"]}?\n\nThey must choose a new one at next sign-in.",
                "Reset Password"))
        {
            return;
        }

        IssuedCredentials c = _service.ResetAdministratorPassword(Convert.ToInt32(row["user_id"]));

        using var shown = new CredentialsForm("Password Reset", c.FullName, c.Username, c.TemporaryPassword);
        shown.ShowDialog(this);
        ReloadData();
    }

    private void Unlock()
    {
        DataRow? row = _list.RequireRow("account");

        if (row == null)
        {
            return;
        }

        _service.Unlock(Convert.ToInt32(row["user_id"]));
        _list.Success("Account unlocked.");
        ReloadData();
    }
}
