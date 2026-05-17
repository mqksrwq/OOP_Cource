using System;
using System.Windows.Forms;

namespace OOP_Cource.Forms
{
    /// <summary>
    /// Элемент управления приветственного экрана
    /// </summary>
    public partial class HelloControl : UserControl
    {
        /// <summary>
        /// Событие запроса закрытия формы приветствия
        /// </summary>
        public event Action CloseRequst;

        /// <summary>
        /// Инициализирует элемент управления
        /// </summary>
        public HelloControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Завершает работу приложения при нажатии кнопки выхода
        /// </summary>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Вызывает событие закрытия формы при нажатии кнопки продолжения
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            CloseRequst?.Invoke();
        }
    }
}
