using System;
using System.Windows.Forms;
using OOP_Cource.Forms;

namespace OOP_Cource
{
    /// <summary>
    /// Начальная форма для перехода к главному интерфейсу управления
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Инициализирует форму
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Скрывает текущую форму, открывает главную форму и закрывается после её завершения
        /// </summary>
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
