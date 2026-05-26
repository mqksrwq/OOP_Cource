using System;
using System.IO;
using System.Windows.Forms;

namespace KursProject_Boyarkin_OOP
{
    /// <summary>
    /// Главная форма приложения «Автобусный парк».
    /// Предоставляет полный интерфейс управления данными: добавление, редактирование
    /// и удаление записей о транспортных средствах, сортировку, фильтрацию, поиск,
    /// а также операции с базой данных через строку меню.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Менеджер таблицы, отвечающий за отображение и обновление <see cref="DataGridView"/>.
        /// </summary>
        private WorkWithTable table;

        /// <summary>
        /// Транспортное средство, выбранное кликом по строке таблицы.
        /// Используется при операциях обновления и удаления.
        /// Равно <c>null</c>, если строка не выбрана.
        /// </summary>
        private BusPark _selectedBus;

        /// <summary>
        /// Создаёт главную форму, инициализирует компоненты, подключает обработчики событий
        /// и настраивает структуру таблицы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Завершаем приложение при закрытии главной формы
            this.FormClosing += (s, e) => Application.Exit();

            table = new WorkWithTable(dataGridView1);
            table.InitialTable();

            dataGridView1.CellClick += DataGridView1_CellClick;

            // Подключаем обработчики пунктов меню
            создатьToolStripMenuItem.Click       += создатьToolStripMenuItem_Click;
            открытьБДToolStripMenuItem.Click     += открытьБДToolStripMenuItem_Click;
            сохранитьКакToolStripMenuItem.Click  += сохранитьКакToolStripMenuItem_Click;
            удалитьБДToolStripMenuItem.Click     += удалитьБДToolStripMenuItem_Click;
            создатьОтчётToolStripMenuItem.Click  += создатьОтчётToolStripMenuItem_Click;
        }

        /// <summary>
        /// Обработчик события загрузки формы.
        /// Расширяет допустимые диапазоны числовых полей, загружает данные из БД,
        /// разблокирует элементы управления и задаёт визуальные параметры таблицы.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Снимаем ограничения NumericUpDown, чтобы значения из БД не обрезались
            numericIncome.Minimum   = numericIncomeUpdate.Minimum   = 0;
            numericExpense.Minimum  = numericExpenseUpdate.Minimum  = 0;
            numericMileage.Minimum  = numericMileageUpdate.Minimum  = 0;
            numericIncome.Maximum   = numericIncomeUpdate.Maximum   = 9999999;
            numericExpense.Maximum  = numericExpenseUpdate.Maximum  = 9999999;
            numericMileage.Maximum  = numericMileageUpdate.Maximum  = 9999999;

            table.UpdateTable();
            UnlockControls();

            // Настраиваем столбцы таблицы: только чтение, центрирование заголовков
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;
                dataGridView1.Columns[i].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView1.AllowUserToAddRows          = false;
            dataGridView1.RowHeadersVisible           = false;
            dataGridView1.AutoSizeColumnsMode         = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToResizeColumns    = false;
            dataGridView1.AllowUserToResizeRows       = false;
            dataGridView1.EnableHeadersVisualStyles   = false;
            dataGridView1.RowsDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            comboBoxField.DropDownStyle       = ComboBoxStyle.DropDownList;
            comboBoxSort.DropDownStyle        = ComboBoxStyle.DropDownList;
            comboBoxRoute.DropDownStyle       = ComboBoxStyle.DropDownList;
            comboBoxRouteUpdate.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Блокирует все элементы управления формы, кроме меню и кнопки «Выход».
        /// Вызывается, когда активная база данных отсутствует.
        /// </summary>
        private void LockControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "menuStrip1" || ctrl.Name == "btnExit")
                    ctrl.Enabled = true;
                else
                    ctrl.Enabled = false;
            }
        }

        /// <summary>
        /// Разблокирует все элементы управления формы.
        /// Вызывается после успешного открытия или создания базы данных.
        /// </summary>
        private void UnlockControls()
        {
            foreach (Control ctrl in this.Controls)
                ctrl.Enabled = true;
        }

        /// <summary>
        /// Обработчик клика по ячейке таблицы.
        /// Сохраняет ссылку на выбранный объект <see cref="BusPark"/> в поле <see cref="_selectedBus"/>
        /// и заполняет поля панели редактирования данными выбранной строки.
        /// </summary>
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= BusPark.Buses.Count) return;

            dataGridView1.Rows[e.RowIndex].Selected = true;
            _selectedBus = BusPark.Buses[e.RowIndex];

            var row = dataGridView1.Rows[e.RowIndex];
            textBoxPlateUpdate.Text  = row.Cells["PlateNumber"].Value?.ToString() ?? "";
            textBoxDriverUpdate.Text = row.Cells["Driver"].Value?.ToString() ?? "";
            comboBoxRouteUpdate.Text = row.Cells["Route"].Value?.ToString() ?? "";

            // Приводим значения к допустимому диапазону NumericUpDown перед присвоением
            decimal income  = Convert.ToDecimal(row.Cells["Income"].Value);
            decimal expense = Convert.ToDecimal(row.Cells["Expense"].Value);
            decimal mileage = Convert.ToDecimal(row.Cells["Mileage"].Value);

            numericIncomeUpdate.Value  = Clamp(income,  numericIncomeUpdate.Minimum,  numericIncomeUpdate.Maximum);
            numericExpenseUpdate.Value = Clamp(expense, numericExpenseUpdate.Minimum, numericExpenseUpdate.Maximum);
            numericMileageUpdate.Value = Clamp(mileage, numericMileageUpdate.Minimum, numericMileageUpdate.Maximum);
        }

        /// <summary>
        /// Ограничивает значение <paramref name="value"/> в пределах диапазона
        /// [<paramref name="min"/>; <paramref name="max"/>].
        /// </summary>
        /// <param name="value">Исходное значение.</param>
        /// <param name="min">Нижняя граница диапазона.</param>
        /// <param name="max">Верхняя граница диапазона.</param>
        /// <returns>
        /// Значение <paramref name="value"/>, зажатое в границы диапазона.
        /// </returns>
        private static decimal Clamp(decimal value, decimal min, decimal max)
            => value < min ? min : value > max ? max : value;

        /// <summary>
        /// Обработчик кнопки «Добавить».
        /// Проверяет заполненность обязательных полей, создаёт объект <see cref="BusPark"/>,
        /// сохраняет его в базе данных и обновляет таблицу.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxPlate.Text)  ||
                    string.IsNullOrWhiteSpace(textBoxDriver.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxRoute.Text))
                {
                    new Exceptions("Поля не могут быть пустыми!");
                    return;
                }

                var bus = new BusPark(
                    textBoxPlate.Text,
                    textBoxDriver.Text,
                    comboBoxRoute.Text,
                    numericIncome.Value,
                    numericExpense.Value,
                    (int)numericMileage.Value
                );

                BusPark.AddBus(bus);
                Database.InsertBus(bus);
                table.UpdateTable();

                textBoxPlate.Clear();
                textBoxDriver.Clear();
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик кнопки «Обновить».
        /// Проверяет, что строка выбрана и поля не пусты, обновляет свойства
        /// объекта <see cref="_selectedBus"/>, сохраняет изменения в БД и перерисовывает таблицу.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedBus == null)
                {
                    new Exceptions("Выберите строку в таблице для обновления!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxPlateUpdate.Text)  ||
                    string.IsNullOrWhiteSpace(textBoxDriverUpdate.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxRouteUpdate.Text))
                {
                    new Exceptions("Поля не могут быть пустыми!");
                    return;
                }

                // Обновляем поля выбранного объекта значениями из полей ввода
                _selectedBus.PlateNumber = textBoxPlateUpdate.Text;
                _selectedBus.Driver      = textBoxDriverUpdate.Text;
                _selectedBus.Route       = comboBoxRouteUpdate.Text;
                _selectedBus.Income      = numericIncomeUpdate.Value;
                _selectedBus.Expense     = numericExpenseUpdate.Value;
                _selectedBus.Mileage     = (int)numericMileageUpdate.Value;

                Database.UpdateBus(_selectedBus);
                table.UpdateTable();

                textBoxPlateUpdate.Clear();
                textBoxDriverUpdate.Clear();
                _selectedBus = null;
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик кнопки «Удалить».
        /// Удаляет выбранное транспортное средство из базы данных и из списка <see cref="BusPark.Buses"/>,
        /// после чего перерисовывает таблицу.
        /// Если строка не выбрана, метод не выполняет никаких действий.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedBus == null) return;

                Database.DeleteBus(_selectedBus.Id);
                BusPark.RemoveBus(_selectedBus);
                _selectedBus = null;
                table.UpdateTable();
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик кнопки «Сортировать».
        /// Проверяет выбор поля и порядка сортировки, затем делегирует выполнение
        /// методу <see cref="WorkWithTable.Sort"/>.
        /// </summary>
        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBoxField.Text))
                {
                    new Exceptions("Выберите поле для сортировки!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(comboBoxSort.Text))
                {
                    new Exceptions("Выберите порядок сортировки!");
                    return;
                }

                bool ascending = comboBoxSort.Text == "По возрастанию";
                table.Sort(comboBoxField.Text, ascending);
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик кнопки «Фильтровать».
        /// Проверяет заполненность полей фильтрации, затем делегирует выполнение
        /// методу <see cref="WorkWithTable.Filter"/>.
        /// </summary>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBoxField.Text))
                {
                    new Exceptions("Выберите поле для фильтрации!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxFilter.Text))
                {
                    new Exceptions("Введите значение для фильтрации!");
                    return;
                }

                table.Filter(comboBoxField.Text, textBoxFilter.Text);
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик кнопки «Найти».
        /// Проверяет наличие поискового запроса, затем делегирует выполнение
        /// методу <see cref="WorkWithTable.Finder"/>.
        /// </summary>
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    new Exceptions("Введите текст для поиска!");
                    return;
                }

                table.Finder(textBoxSearch.Text);
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик кнопки «Сбросить фильтр».
        /// Восстанавливает полный список записей и очищает поле ввода фильтра.
        /// </summary>
        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            table.CancelFilter();
            textBoxFilter.Clear();
        }

        /// <summary>
        /// Обработчик кнопки «Сбросить сортировку».
        /// Восстанавливает исходный порядок строк таблицы.
        /// </summary>
        private void btnResetSort_Click(object sender, EventArgs e)
        {
            table.CancelSort();
        }

        /// <summary>
        /// Обработчик кнопки «Сбросить поиск».
        /// Снимает подсветку результатов поиска и очищает поле ввода.
        /// </summary>
        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            table.CancelFinder();
            textBoxSearch.Clear();
        }

        /// <summary>
        /// Обработчик кнопки «Выход». Завершает работу приложения.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();

        /// <summary>
        /// Обработчик пункта меню «Создать».
        /// Открывает диалог ввода имени, создаёт новую базу данных PostgreSQL,
        /// обновляет заголовок окна и разблокирует элементы управления.
        /// </summary>
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var inputForm = new CreationDataBase())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    Database.CreateDatabase(inputForm.DatabaseName);
                    BusPark.Buses.Clear();
                    table.UpdateTable();
                    UnlockControls();
                    this.Text = "Автобусный парк / " + inputForm.DatabaseName;
                }
            }
        }

        /// <summary>
        /// Обработчик пункта меню «Открыть БД».
        /// Открывает диалог выбора файла <c>.sql</c>, восстанавливает базу данных
        /// из дампа и обновляет заголовок окна.
        /// </summary>
        private void открытьБДToolStripMenuItem_Click(object sender, EventArgs e)
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
                    table.UpdateTable();
                    UnlockControls();
                    this.Text = "Автобусный парк / " +
                        Path.GetFileNameWithoutExtension(openDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Обработчик пункта меню «Сохранить как».
        /// Открывает диалог сохранения файла и экспортирует текущую базу данных
        /// в файл <c>.sql</c> через <c>pg_dump</c>.
        /// </summary>
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog
            {
                Filter   = "SQL файлы (*.sql)|*.sql",
                Title    = "Сохранить базу данных",
                FileName = Database.CurrentDatabase + ".sql"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
                Database.SaveDatabase(saveDialog.FileName);
        }

        /// <summary>
        /// Обработчик пункта меню «Удалить БД».
        /// Запрашивает подтверждение пользователя, удаляет текущую базу данных PostgreSQL,
        /// очищает таблицу и блокирует элементы управления.
        /// </summary>
        private void удалитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                $"Вы действительно хотите удалить базу данных '{Database.CurrentDatabase}'?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Database.DeleteDatabase(Database.CurrentDatabase);
                BusPark.Buses.Clear();
                table.UpdateTable();
                LockControls();
                this.Text = "Автобусный парк";
            }
        }

        /// <summary>
        /// Обработчик пункта меню «Создать отчёт».
        /// Проверяет наличие данных, открывает диалог сохранения файла <c>.pdf</c>
        /// и экспортирует текущую таблицу в PDF-документ.
        /// </summary>
        private void создатьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BusPark.Buses.Count == 0)
            {
                new Exceptions("Таблица пуста — нечего экспортировать!");
                return;
            }

            var saveDialog = new SaveFileDialog
            {
                Filter   = "PDF файл (*.pdf)|*.pdf",
                Title    = "Сохранить отчёт",
                FileName = "Отчёт_автобусный_парк.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
                Database.SaveTableToPdf(saveDialog.FileName);
        }

        // Делегирующие обработчики — перенаправляют события кнопок на основные методы
        private void button1_Click(object sender, EventArgs e) => btnFilter_Click(sender, e);
        private void button2_Click(object sender, EventArgs e) => btnSort_Click(sender, e);
        private void button3_Click(object sender, EventArgs e) => btnFind_Click(sender, e);
        private void button4_Click(object sender, EventArgs e) => btnDelete_Click(sender, e);
        private void button5_Click(object sender, EventArgs e) => btnResetFilter_Click(sender, e);
        private void button6_Click(object sender, EventArgs e) => btnResetSort_Click(sender, e);
        private void button7_Click(object sender, EventArgs e) => btnResetSearch_Click(sender, e);
        private void button8_Click(object sender, EventArgs e) => btnExit_Click(sender, e);

        // Заглушки событий, генерируемые Designer
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void textBoxPlate_TextChanged(object sender, EventArgs e) { }
        private void textBoxDriver_TextChanged(object sender, EventArgs e) { }
        private void comboBoxRoute_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numericIncome_ValueChanged(object sender, EventArgs e) { }
        private void numericExpense_ValueChanged(object sender, EventArgs e) { }
        private void numericMileage_ValueChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void textBoxPlateUpdate_TextChanged(object sender, EventArgs e) { }
        private void comboBoxRouteUpdate_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numericIncomeUpdate_ValueChanged(object sender, EventArgs e) { }
        private void numericExpenseUpdate_ValueChanged(object sender, EventArgs e) { }
        private void numericMileageUpdate_ValueChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e) { }
    }
}
