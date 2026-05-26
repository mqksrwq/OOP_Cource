using System.Windows.Forms;

namespace KursProject_Boyarkin_OOP
{
    /// <summary>
    /// Точка входа приложения «Автобусный парк».
    /// Содержит метод <see cref="Main"/>, который инициализирует WinForms-среду и запускает приложение.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Главный метод приложения. Настраивает режим DPI, включает визуальные стили
        /// и открывает экран-заставку <see cref="StartForm"/>.
        /// </summary>
        [System.STAThread]
        static void Main()
        {
            // Поддержка высокого DPI — масштабирование через системные настройки Windows
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
