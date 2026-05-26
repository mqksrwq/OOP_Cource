using System;
using System.Windows.Forms;

namespace KursProject_Boyarkin_OOP
{
    /// <summary>
    /// Вспомогательный класс для унифицированного отображения ошибок пользователю.
    /// При создании экземпляра автоматически показывает диалоговое окно с описанием ошибки.
    /// Наследует <see cref="Exception"/>, поэтому может использоваться как стандартное исключение.
    /// </summary>
    internal class Exceptions : Exception
    {
        /// <summary>
        /// Текст сообщения, отображаемый пользователю в диалоговом окне.
        /// </summary>
        public string UserMessage { get; }

        /// <summary>
        /// Создаёт экземпляр исключения и немедленно показывает MessageBox с описанием ошибки.
        /// </summary>
        /// <param name="userMessage">Текст сообщения об ошибке на русском языке.</param>
        public Exceptions(string userMessage) : base("Произошла ошибка: " + userMessage)
        {
            UserMessage = userMessage;

            // Отображаем модальное окно с текстом ошибки и иконкой предупреждения
            MessageBox.Show(UserMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Возвращает текстовое представление ошибки — пользовательское сообщение.
        /// </summary>
        /// <returns>Строка с описанием ошибки.</returns>
        public override string ToString() => UserMessage;
    }
}
