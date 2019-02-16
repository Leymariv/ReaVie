using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public interface IReavie
    {
        Form ParentForm { get; }
        UserControl Next { get; }
        UserControl Previous { get; }
    }
}