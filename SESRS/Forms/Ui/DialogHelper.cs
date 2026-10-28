using SESRS.Helpers;

namespace SESRS.Forms;

/// <summary>Shared behavior for the Save button of dialogs: loading state, no double submit, inline errors.</summary>
internal static class DialogHelper
{
    /// <summary>
    /// Runs the action. If it throws or returns a message, the dialog stays open (keeping what was typed)
    /// and the message is shown in <paramref name="error"/>. Otherwise the dialog closes with OK.
    /// </summary>
    public static void Submit(Form form, Label error, Button save, Button cancel, Func<string?> action)
    {
        error.Text = "";
        SetBusy(form, save, cancel, true);

        try
        {
            string? problem = action();

            if (problem != null)
            {
                error.Text = problem;
                return;
            }

            form.DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            error.Text = ErrorHandler.Friendly(ex);
        }
        finally
        {
            SetBusy(form, save, cancel, false);
        }
    }

    public static void Submit(Form form, Label error, Button save, Button cancel, Action action)
    {
        Submit(form, error, save, cancel, () =>
        {
            action();
            return null;
        });
    }

    private static void SetBusy(Form form, Button save, Button cancel, bool busy)
    {
        form.UseWaitCursor = busy;
        save.Enabled = !busy;
        cancel.Enabled = !busy;
    }

    /// <summary>Fills a combo box with value-carrying items and optionally selects one by value.</summary>
    public static void Fill(ComboBox box, IEnumerable<ChoiceItem> items, object? selectedValue = null)
    {
        box.Items.Clear();

        foreach (ChoiceItem item in items)
        {
            box.Items.Add(item);
        }

        Select(box, selectedValue);
    }

    public static void Select(ComboBox box, object? value)
    {
        if (value == null)
        {
            return;
        }

        box.SelectedItem = box.Items.OfType<ChoiceItem>().FirstOrDefault(i => Equals(i.Value, value));
    }

    /// <summary>The Value of the selected ChoiceItem, or default when nothing is selected.</summary>
    public static T? Value<T>(ComboBox box)
    {
        return box.SelectedItem is ChoiceItem { Value: T value } ? value : default;
    }

    public static bool HasSelection(ComboBox box) => box.SelectedItem != null;
}
