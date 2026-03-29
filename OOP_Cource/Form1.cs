using System;
using System.Windows.Forms;
using OOP_Cource.Forms;

namespace OOP_Cource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Hide();

            using (var mainForm = new MainForm())
            {
                mainForm.ShowDialog();
            }

            Close();
        }
    }
}
