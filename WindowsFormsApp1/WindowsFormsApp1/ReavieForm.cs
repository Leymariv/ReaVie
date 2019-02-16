using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ReavieForm : Form
    {
        public ReavieForm()
        {
            InitializeComponent();
            var uc = new LoginUC(this);
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }
    }
}
