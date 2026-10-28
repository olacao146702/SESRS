using System.Globalization;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class GradingComponentDialog : Form
{
    private readonly GradeService _service = new();
    private readonly GradeComponent? _existing;

    public GradingComponentDialog(GradeComponent? existing = null)
    {
        InitializeComponent();
        _existing = existing;
        Text = existing == null ? "Add Grading Component" : "Edit Grading Component";

        var scopes = new List<ChoiceItem> { new(0, "All subjects (default)") };
        scopes.AddRange(new CurriculumService().GetAllSubjects().Select(s => new ChoiceItem(s.Id, s.Label)));
        DialogHelper.Fill(cmbScope, scopes, existing?.SubjectId ?? 0);

        if (existing != null)
        {
            cmbScope.Enabled = false;
            txtName.Text = existing.Name;
            txtWeight.Text = existing.Weight.ToString("0.##");
            nudOrder.Value = existing.SortOrder;
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            if (!decimal.TryParse(txtWeight.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal weight))
            {
                return "Enter the weight as a number, for example 30.";
            }

            int scope = DialogHelper.Value<int>(cmbScope);
            int? subjectId = _existing != null ? _existing.SubjectId : (scope == 0 ? null : scope);

            _service.SaveComponent(new GradeComponent(_existing?.ComponentId ?? 0, subjectId, txtName.Text.Trim(),
                weight, (int)nudOrder.Value));

            return null;
        });
    }
}
