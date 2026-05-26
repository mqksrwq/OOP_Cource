using System;
using System.Windows.Forms;

namespace KursProject_Boyarkin_OOP
{
    /// <summary>
    /// Форма выбора действия с базой данных, открываемая после экрана-заставки.
    /// Предоставляет пользователю два варианта: создать новую БД или подключиться
    /// к существующей, восстановив её из файла <c>.sql</c>.
    /// </summary>
    public partial class SelectDbForm : Form
    {
        /// <summary>
        /// Главная форма приложения, которая открывается после успешного выбора базы данных.
        /// Создаётся заранее, чтобы при повторных обращениях состояние сохранялось.
        /// </summary>
        private MainForm mainForm = new MainForm();

        /// <summary>
        /// Создаёт экземпляр формы выбора БД, задаёт заголовок окна
        /// и подписывается на событие закрытия для корректного завершения приложения.
        /// </summary>
        public SelectDbForm()
        {
            InitializeComponent();
            this.Text = "Автобусный парк — выбор базы данных";

            // Закрытие этой формы завершает всё приложение
            this.FormClosing += (s, e) => Application.Exit();
        }

        /// <summary>
        /// Обработчик кнопки «Создать базу данных».
        /// Открывает диалог ввода имени новой БД; при подтверждении создаёт БД,
        /// загружает данные и переходит к главной форме.
        /// </summary>
        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            using (var inputForm = new CreationDataBase())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Создаём БД в PostgreSQL и загружаем начальные данные
                        Database.CreateDatabase(inputForm.DatabaseName);
                        Database.LoadFromDatabase();
                        mainForm.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        new Exceptions("Ошибка создания БД: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки «Подключиться к существующей».
        /// Открывает диалог выбора файла <c>.sql</c>; при выборе восстанавливает
        /// базу данных из дампа и переходит к главной форме.
        /// </summary>
        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "SQL файлы (*.sql)|*.sql",
                Title  = "Открыть базу данных"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                bool success = Database.OpenSqlFile(openDialog.FileName);
                if (success)
                {
                    mainForm.Show();
                    this.Hide();
                }
            }
        }
    }
}
