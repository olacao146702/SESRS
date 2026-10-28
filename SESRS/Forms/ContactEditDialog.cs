using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>A student edits only the contact details the school allows (email, phone, address).</summary>
public partial class ContactEditDialog : Form
{
    private readonly StudentPortalService _portal = new();
    private readonly int _studentId;

    public ContactEditDialog(StudentProfile profile)
    {
        InitializeComponent();
        _studentId = profile.StudentId;

        txtEmail.Text = profile.Email;
        txtPhone.Text = profile.Phone;
        txtAddress.Text = profile.Address;
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
            _portal.UpdateContact(_studentId, txtEmail.Text, txtPhone.Text, txtAddress.Text));
    }
}
