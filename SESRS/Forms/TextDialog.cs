namespace SESRS.Forms;

/// <summary>Read-only dialog for reading a longer message (such as an announcement).</summary>
public partial class TextDialog : Form
{
    public TextDialog(string title, string meta, string body)
    {
        InitializeComponent();

        Text = title;
        lblHeader.Text = title + "\n" + meta;
        txtBody.Text = body;
    }
}
