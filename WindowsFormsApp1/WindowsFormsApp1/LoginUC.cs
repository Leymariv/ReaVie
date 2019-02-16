using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginUC : UserControl, IReavie
    {
        public LoginUC(Form reavieForm)
        {
            InitializeComponent();
            ParentForm = reavieForm;
            Next = new MainMenuUC(ParentForm, this);
            Previous = null;
            Next.Dock = DockStyle.Fill;
            Next.Visible = false;
            ParentForm.Controls.Add(Next);
        }

        public Form ParentForm { get; }
        public UserControl Next { get; }
        public UserControl Previous { get; }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Next.Visible = true;
        }
    }
}
