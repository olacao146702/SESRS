using SESRS.Services;

namespace SESRS.Forms;

public partial class PrerequisiteDialog : Form
{
    private readonly CurriculumService _service = new();
    private readonly int _subjectId;

    public PrerequisiteDialog(int subjectId, string subjectCode)
    {
        InitializeComponent();
        _subjectId = subjectId;
        Text = "Prerequisites for " + subjectCode;

        var current = _service.GetPrerequisiteIds(subjectId);

        foreach (var (id, label) in _service.GetAllSubjects().Where(s => s.Id != subjectId))
        {
            clbRequired.Items.Add(new ChoiceItem(id, label), current.Contains(id));
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            var chosen = clbRequired.CheckedItems.Cast<ChoiceItem>().Select(i => (int)i.Value).ToList();
            _service.SetPrerequisites(_subjectId, chosen);
        });
    }
}
