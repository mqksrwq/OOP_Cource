using System.Windows.Forms;

namespace KursProject_Boyarkin_OOP
{
    /// <summary>
    /// Диалоговая форма для ввода имени новой базы данных.
    /// Возвращает <see cref="DialogResult.OK"/> и заполняет свойство <see cref="DatabaseName"/>
    /// при подтверждении, либо <see cref="DialogResult.Cancel"/> при отмене.
    /// </summary>
    public partial class CreationDataBase : Form
    {
        /// <summary>
        /// Имя базы данных, введённое пользователем.
        /// Заполняется только при нажатии кнопки «Создать».
        /// </summary>
        public string DatabaseName { get; private set; }

        /// <summary>
        /// Создаёт экземпляр диалога и инициализирует компоненты формы.
        /// </summary>
        public CreationDataBase() => InitializeComponent();

        /// <summary>
        /// Обработчик кнопки «Создать».
        /// Проверяет, что поле имени не пустое, сохраняет введённое имя
        /// и закрывает диалог с результатом <see cref="DialogResult.OK"/>.
        /// </summary>
        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите имя базы данных.");
                return;
            }

            // Сохраняем имя без лишних пробелов по краям
            DatabaseName      = textBoxName.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Обработчик кнопки «Отмена».
        /// Закрывает диалог с результатом <see cref="DialogResult.Cancel"/> без создания БД.
        /// </summary>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CreationDataBase_Load(object sender, System.EventArgs e) { }
    }
}
