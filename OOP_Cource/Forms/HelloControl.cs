using System;
using System.Windows.Forms;

namespace OOP_Cource.Forms
{
    public partial class HelloControl : UserControl
    {
        public event Action CloseRequst;

        public HelloControl()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            CloseRequst?.Invoke();
        }
    }
}
