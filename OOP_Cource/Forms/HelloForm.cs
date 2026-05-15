using System;
using System.Windows.Forms;

namespace OOP_Cource.Forms
{
    /// <summary>
    /// Главная форма приветствия
    /// </summary>
    public partial class HelloForm : Form
    {
        private readonly Timer _timer;
        private readonly HelloControl _helloControl;
        private bool _isCloseRequested;

        public HelloForm()
        {
            InitializeComponent();

            _timer = new Timer();
            _timer.Interval = 10000;
            _timer.Tick += Timer_Tick;

            _helloControl = new HelloControl();
            _helloControl.CloseRequst += OnCloseRequest;
        }

        private void HelloForm_Load(object sender, EventArgs e)
        {
            _helloControl.Dock = DockStyle.Fill;
            Controls.Add(_helloControl);
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            if (!_isCloseRequested)
            {
                Close();
            }
        }

        private void OnCloseRequest()
        {
            _isCloseRequested = true;
            _timer.Stop();
            Close();
        }
    }
}
