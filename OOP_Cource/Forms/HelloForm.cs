using System;
using System.Windows.Forms;

namespace OOP_Cource.Forms
{
    /// <summary>
    /// Приветственная форма, отображаемая при запуске приложения
    /// </summary>
    public partial class HelloForm : Form
    {
        private readonly Timer _timer;
        private readonly HelloControl _helloControl;
        private bool _isCloseRequested;

        /// <summary>
        /// Инициализирует форму, таймер автозакрытия и элемент управления приветствием
        /// </summary>
        public HelloForm()
        {
            InitializeComponent();

            _timer = new Timer();
            _timer.Interval = 10000;
            _timer.Tick += Timer_Tick;

            _helloControl = new HelloControl();
            _helloControl.CloseRequst += OnCloseRequest;
        }

        /// <summary>
        /// Добавляет элемент управления на форму и запускает таймер автозакрытия
        /// </summary>
        private void HelloForm_Load(object sender, EventArgs e)
        {
            _helloControl.Dock = DockStyle.Fill;
            Controls.Add(_helloControl);
            _timer.Start();
        }

        /// <summary>
        /// Закрывает форму по истечении таймера, если пользователь не нажал кнопку
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            if (!_isCloseRequested)
            {
                Close();
            }
        }

        /// <summary>
        /// Обрабатывает запрос закрытия формы от элемента управления
        /// </summary>
        private void OnCloseRequest()
        {
            _isCloseRequested = true;
            _timer.Stop();
            Close();
        }
    }
}
