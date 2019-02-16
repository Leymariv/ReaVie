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
    public partial class MainMenuUC : UserControl, IReavie
    {
        public MainMenuUC(Form parentForm, UserControl loginUc) 
        {
            InitializeComponent();
            ParentForm = parentForm;
            Previous = loginUc;
        }

        public Form ParentForm { get; }
        public UserControl Next { get; }
        public UserControl Previous { get; }
    }
}
