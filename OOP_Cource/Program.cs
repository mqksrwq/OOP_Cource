using System.Windows.Forms;
using OOP_Cource.Forms;
using System;

namespace OOP_Cource
{
    /// <summary>
    /// Точка входа в приложение
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Главный метод — запускает приложение с формой администратора
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AdminForm());
        }
    }
}
