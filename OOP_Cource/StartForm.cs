using System;
using System.Windows.Forms;

namespace KursProject_Boyarkin_OOP
{
    /// <summary>
    /// Экран-заставка, отображаемый при запуске приложения.
    /// Автоматически закрывается через <see cref="SECONDS"/> миллисекунд или немедленно
    /// по нажатию кнопки «Начать», после чего открывается форма выбора базы данных.
    /// </summary>
    public partial class StartForm : Form
    {
        /// <summary>
        /// Время отображения заставки в миллисекундах (10 секунд).
        /// </summary>
        private const int SECONDS = 10000;

        /// <summary>
        /// Форма выбора действия с базой данных, которая открывается после закрытия заставки.
        /// </summary>
        private SelectDbForm selectDbForm = new SelectDbForm();

        /// <summary>
        /// Таймер, управляющий автоматическим закрытием заставки.
        /// </summary>
        private Timer _timer = new Timer();

        /// <summary>
        /// Создаёт экземпляр экрана-заставки и инициализирует компоненты формы.
        /// </summary>
        public StartForm() => InitializeComponent();

        /// <summary>
        /// Скрывает заставку и переходит к форме выбора базы данных.
        /// </summary>
        private void CloseStartForm()
        {
            selectDbForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Обработчик события загрузки формы.
        /// Запускает таймер на <see cref="SECONDS"/> миллисекунд,
        /// по истечении которых заставка автоматически скрывается.
        /// </summary>
        private void StartForm_Load(object sender, EventArgs e)
        {
            _timer.Interval = SECONDS;

            // По срабатыванию таймера останавливаем его и переходим к следующей форме
            _timer.Tick += (s, args) =>
            {
                _timer.Stop();
                _timer.Dispose();
                CloseStartForm();
            };

            _timer.Start();
        }

        /// <summary>
        /// Обработчик нажатия кнопки «Начать».
        /// Досрочно останавливает таймер и открывает форму выбора базы данных.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer.Dispose();
            CloseStartForm();
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}
