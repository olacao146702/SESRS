namespace SESRS.Forms;

/// <summary>Colors and fonts shared by code that draws or recolors controls at run time.</summary>
internal static class UiStyle
{
    public static readonly Color Brand = Color.DarkGreen;
    public static readonly Color Sidebar = Color.FromArgb(24, 82, 58);
    public static readonly Color Muted = Color.DimGray;

    // One shared instance: grids ask for this on every repaint, so it must not allocate a new Font each time.
    public static readonly Font Bold = new("Segoe UI", 9F, FontStyle.Bold);
}
