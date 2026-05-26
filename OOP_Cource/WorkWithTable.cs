using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KursProject_Boyarkin_OOP
{
    /// <summary>
    /// Управляет отображением данных о транспортных средствах в компоненте <see cref="DataGridView"/>.
    /// Предоставляет методы для инициализации, обновления, сортировки, фильтрации и поиска строк таблицы.
    /// </summary>
    internal class WorkWithTable
    {
        /// <summary>
        /// Ссылка на компонент таблицы, которым управляет данный объект.
        /// </summary>
        private DataGridView dataGridView;

        /// <summary>
        /// Резервная копия списка ТС до применения сортировки или фильтрации.
        /// Используется для восстановления исходного порядка при отмене.
        /// </summary>
        private List<BusPark> default_List;

        /// <summary>
        /// Создаёт экземпляр менеджера таблицы, привязанного к указанному <see cref="DataGridView"/>.
        /// </summary>
        /// <param name="dataGridView">Компонент таблицы, которым требуется управлять.</param>
        public WorkWithTable(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        /// <summary>
        /// Инициализирует структуру таблицы: удаляет существующие столбцы и создаёт новые
        /// с именами и заголовками, соответствующими полям модели <see cref="BusPark"/>.
        /// </summary>
        public void InitialTable()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("PlateNumber", "Номер ТС");
            dataGridView.Columns.Add("Driver",      "Водитель");
            dataGridView.Columns.Add("Route",       "Маршрут");
            dataGridView.Columns.Add("Income",      "Доход (руб/д)");
            dataGridView.Columns.Add("Expense",     "Расход (руб/д)");
            dataGridView.Columns.Add("Mileage",     "Пробег (км/д)");
        }

        /// <summary>
        /// Добавляет одну строку в таблицу на основе переданного объекта <see cref="BusPark"/>.
        /// </summary>
        /// <param name="bus">Транспортное средство, данные которого нужно отобразить.</param>
        public void AddBusToTable(BusPark bus)
        {
            dataGridView.Rows.Add(
                bus.PlateNumber,
                bus.Driver,
                bus.Route,
                bus.Income,
                bus.Expense,
                bus.Mileage
            );
        }

        /// <summary>
        /// Полностью перерисовывает таблицу на основе текущего содержимого <see cref="BusPark.Buses"/>.
        /// Все существующие строки удаляются и создаются заново.
        /// </summary>
        public void UpdateTable()
        {
            dataGridView.Rows.Clear();
            foreach (var bus in BusPark.Buses)
                AddBusToTable(bus);
        }

        /// <summary>
        /// Сортирует список <see cref="BusPark.Buses"/> по указанному столбцу и перерисовывает таблицу.
        /// Перед сортировкой сохраняет резервную копию списка для возможности отмены.
        /// </summary>
        /// <param name="column">Заголовок столбца, по которому выполняется сортировка.</param>
        /// <param name="ascending">
        /// <c>true</c> — сортировка по возрастанию; <c>false</c> — по убыванию.
        /// </param>
        public void Sort(string column, bool ascending)
        {
            // Сохраняем оригинальный список для возможности отмены сортировки
            default_List = new List<BusPark>(BusPark.Buses);

            switch (column)
            {
                case "Номер ТС":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.PlateNumber).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.PlateNumber).ToList();
                    break;
                case "Водитель":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.Driver).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.Driver).ToList();
                    break;
                case "Маршрут":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.Route).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.Route).ToList();
                    break;
                case "Доход (руб/д)":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.Income).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.Income).ToList();
                    break;
                case "Расход (руб/д)":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.Expense).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.Expense).ToList();
                    break;
                case "Пробег (км/д)":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.Mileage).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.Mileage).ToList();
                    break;
            }

            UpdateTable();
        }

        /// <summary>
        /// Фильтрует список <see cref="BusPark.Buses"/> по указанному столбцу и значению,
        /// оставляя только те записи, в которых поле содержит заданную подстроку.
        /// Перед фильтрацией сохраняет резервную копию списка для возможности отмены.
        /// </summary>
        /// <param name="column">Заголовок столбца, по которому выполняется фильтрация.</param>
        /// <param name="value">Подстрока, которую должно содержать значение поля.</param>
        public void Filter(string column, string value)
        {
            // Сохраняем оригинальный список для возможности отмены фильтрации
            default_List = new List<BusPark>(BusPark.Buses);

            switch (column)
            {
                case "Номер ТС":
                    BusPark.Buses = BusPark.Buses.Where(b => b.PlateNumber.Contains(value)).ToList();
                    break;
                case "Водитель":
                    BusPark.Buses = BusPark.Buses.Where(b => b.Driver.Contains(value)).ToList();
                    break;
                case "Маршрут":
                    BusPark.Buses = BusPark.Buses.Where(b => b.Route.Contains(value)).ToList();
                    break;
                case "Доход (руб/д)":
                    BusPark.Buses = BusPark.Buses.Where(b => b.Income.ToString().Contains(value)).ToList();
                    break;
                case "Расход (руб/д)":
                    BusPark.Buses = BusPark.Buses.Where(b => b.Expense.ToString().Contains(value)).ToList();
                    break;
                case "Пробег (км/д)":
                    BusPark.Buses = BusPark.Buses.Where(b => b.Mileage.ToString().Contains(value)).ToList();
                    break;
            }

            UpdateTable();
        }

        /// <summary>
        /// Выполняет поиск по всем видимым столбцам таблицы.
        /// Строки, содержащие искомый текст хотя бы в одном поле, подсвечиваются жёлто-зелёным цветом;
        /// остальные строки возвращаются к белому фону.
        /// </summary>
        /// <param name="searchText">Текст для поиска (регистр игнорируется).</param>
        public void Finder(string searchText)
        {
            // Сбрасываем подсветку всех строк перед новым поиском
            foreach (DataGridViewRow row in dataGridView.Rows)
                row.DefaultCellStyle.BackColor = Color.White;

            searchText = searchText.ToLower();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Проверяем наличие подстроки хотя бы в одном поле строки
                bool containsText =
                    row.Cells["PlateNumber"].Value.ToString().ToLower().Contains(searchText) ||
                    row.Cells["Driver"].Value.ToString().ToLower().Contains(searchText)      ||
                    row.Cells["Route"].Value.ToString().ToLower().Contains(searchText)       ||
                    row.Cells["Income"].Value.ToString().ToLower().Contains(searchText)      ||
                    row.Cells["Expense"].Value.ToString().ToLower().Contains(searchText)     ||
                    row.Cells["Mileage"].Value.ToString().ToLower().Contains(searchText);

                if (containsText)
                    row.DefaultCellStyle.BackColor = Color.YellowGreen;
            }
        }

        /// <summary>
        /// Отменяет применённую сортировку, восстанавливая оригинальный порядок записей,
        /// сохранённый в резервной копии <see cref="default_List"/>.
        /// Если сортировка не была применена, метод не выполняет никаких действий.
        /// </summary>
        public void CancelSort()
        {
            if (default_List == null) return;
            BusPark.Buses = default_List;
            default_List  = null;
            UpdateTable();
        }

        /// <summary>
        /// Отменяет применённый фильтр, восстанавливая полный список записей
        /// из резервной копии <see cref="default_List"/>.
        /// Если фильтр не был применён, метод не выполняет никаких действий.
        /// </summary>
        public void CancelFilter()
        {
            if (default_List == null) return;
            BusPark.Buses = default_List;
            default_List  = null;
            UpdateTable();
        }

        /// <summary>
        /// Снимает подсветку поиска со всех строк таблицы, возвращая им белый фон.
        /// </summary>
        public void CancelFinder()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
                row.DefaultCellStyle.BackColor = Color.White;
        }
    }
}
