namespace SESRS.Forms;

/// <summary>An item for a ComboBox that carries a value (such as a database id) and shows a label.</summary>
public sealed record ChoiceItem(object Value, string Text)
{
    public override string ToString() => Text;
}
