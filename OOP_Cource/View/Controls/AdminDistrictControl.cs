using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP_Cource.Controller;
using OOP_Cource.DTO;
using OOP_Cource.Models;
using OOP_Cource.Utils;

namespace OOP_Cource.View.Controls
{
    public partial class AdminDistrictControl : UserControl
    {
        private readonly VehicleController _controller;
        private readonly DistrictEnum _district;

        public event Action<DistrictEnum> AddButtonEvent;
        public event Action<int> ChangeButtonEvent;
        public event Action CloseButtonEvent;

        public AdminDistrictControl(VehicleController controller, DistrictEnum district)
        {
            InitializeComponent();
            _controller = controller;
            _district = district;
            ConfigureVehicleGrid();
        }

        private async void AdminDistrictControl_Load(object sender, EventArgs e)
        {
            await LoadAllVehiclesAsync();
        }

        private async Task LoadAllVehiclesAsync()
        {
            var vehicles = await _controller.GetByDistrictAsync(GetCurrentDistrictName());
            LoadVehiclesByList(vehicles);
        }

        private string GetCurrentDistrictName()
        {
            return DistrictExtension.GetDisplayName(_district);
        }

        private void ConfigureVehicleGrid()
        {
            if (VehicleDataGridView.Columns.Count > 0)
            {
                return;
            }

            VehicleDataGridView.Columns.Add("Id", "ID");
            VehicleDataGridView.Columns.Add("Number", "Гос. номер");
            VehicleDataGridView.Columns.Add("District", "Район");
            VehicleDataGridView.Columns.Add("Model", "Модель");
            VehicleDataGridView.Columns.Add("Capacity", "Вместимость");
            VehicleDataGridView.Columns.Add("Status", "Статус");

            VehicleDataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Изменить",
                Text = "Изменить",
                UseColumnTextForButtonValue = true
            });

            VehicleDataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Удалить",
                Text = "Удалить",
                UseColumnTextForButtonValue = true
            });
        }

        private void LoadVehiclesByList(List<VehicleDTO> vehicles)
        {
            VehicleDataGridView.Rows.Clear();

            foreach (var vehicle in vehicles)
            {
                var rowIndex = VehicleDataGridView.Rows.Add();
                VehicleDataGridView.Rows[rowIndex].Cells[0].Value = vehicle.Id;
                VehicleDataGridView.Rows[rowIndex].Cells[1].Value = vehicle.Number;
                VehicleDataGridView.Rows[rowIndex].Cells[2].Value = vehicle.District;
                VehicleDataGridView.Rows[rowIndex].Cells[3].Value = vehicle.Model;
                VehicleDataGridView.Rows[rowIndex].Cells[4].Value = vehicle.Capacity;
                VehicleDataGridView.Rows[rowIndex].Cells[5].Value = vehicle.Status;
                VehicleDataGridView.Rows[rowIndex].Cells[6].Value = "Изменить";
                VehicleDataGridView.Rows[rowIndex].Cells[7].Value = "Удалить";
            }
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CriteriaComboBox.SelectedIndex == 0)
                {
                    if (!int.TryParse(CriteriaValueTextBox.Text, out int id))
                        throw new ArgumentException("Id должен быть числом!");

                    var vehicle = await _controller.GetByIdAsync(id);
                    LoadVehiclesByList(vehicle.District == GetCurrentDistrictName()
                        ? new List<VehicleDTO> { vehicle }
                        : new List<VehicleDTO>());
                }
                else if (CriteriaComboBox.SelectedIndex == 1)
                {
                    var vehicles = await _controller.GetByNumberAsync(CriteriaValueTextBox.Text);
                    LoadVehiclesByList(FilterCurrentDistrict(vehicles));
                }
                else if (CriteriaComboBox.SelectedIndex == 2)
                {
                    var vehicles = await _controller.GetByModelAsync(CriteriaValueTextBox.Text);
                    LoadVehiclesByList(FilterCurrentDistrict(vehicles));
                }
                else if (CriteriaComboBox.SelectedIndex == 3)
                {
                    if (!int.TryParse(CriteriaValueTextBox.Text, out int capacity))
                        throw new ArgumentException("Вместимость должна быть числом!");

                    var vehicles = await _controller.GetByCapacityAsync(capacity);
                    LoadVehiclesByList(FilterCurrentDistrict(vehicles));
                }
                else if (CriteriaComboBox.SelectedIndex == 4)
                {
                    var vehicles = await _controller.GetByStatusAsync(CriteriaValueTextBox.Text);
                    LoadVehiclesByList(FilterCurrentDistrict(vehicles));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка поиска транспорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ClearButton_Click(object sender, EventArgs e)
        {
            CriteriaComboBox.SelectedItem = null;
            CriteriaValueTextBox.Text = string.Empty;
            await LoadAllVehiclesAsync();
        }

        private List<VehicleDTO> FilterCurrentDistrict(List<VehicleDTO> vehicles)
        {
            var district = GetCurrentDistrictName();
            return vehicles.Where(vehicle => vehicle.District == district).ToList();
        }

        private async void VehicleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 7)
                {
                    var result = MessageBox.Show("Вы действительно хотите удалить транспорт?",
                        "Согласие на удаление",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        await _controller.DeleteAsync((int)VehicleDataGridView.Rows[e.RowIndex].Cells[0].Value);
                        await LoadAllVehiclesAsync();
                        MessageBox.Show("Транспорт успешно удалён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == 6)
                {
                    int id = (int)VehicleDataGridView.Rows[e.RowIndex].Cells[0].Value;
                    ChangeButtonEvent?.Invoke(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddButtonEvent?.Invoke(_district);
        }

        private async void DeleteAllButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить все записи по району?",
                "Согласие на удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                await _controller.DeleteByDistrictAsync(GetCurrentDistrictName());
                await LoadAllVehiclesAsync();
                MessageBox.Show("Все записи района удалены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            CloseButtonEvent?.Invoke();
        }

        private async void ReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    dialog.FileName = $"report_{GetCurrentDistrictName()}.txt";

                    if (dialog.ShowDialog() != DialogResult.OK)
                        return;

                    var vehicles = await _controller.GetByDistrictAsync(GetCurrentDistrictName());
                    File.WriteAllText(dialog.FileName, CreateReport(vehicles), new UTF8Encoding(true));
                    MessageBox.Show("Отчет успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения отчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CsvButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    dialog.FileName = $"vehicles_{GetCurrentDistrictName()}.csv";

                    if (dialog.ShowDialog() != DialogResult.OK)
                        return;

                    var vehicles = await _controller.GetByDistrictAsync(GetCurrentDistrictName());
                    File.WriteAllText(dialog.FileName, CreateCsv(vehicles), new UTF8Encoding(true));
                    MessageBox.Show("CSV файл успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CreateReport(List<VehicleDTO> vehicles)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Отчет по транспортным средствам автопарка");
            builder.AppendLine($"Район: {GetCurrentDistrictName()}");
            builder.AppendLine($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}");
            builder.AppendLine($"Количество записей: {vehicles.Count}");
            builder.AppendLine();

            if (vehicles.Count == 0)
            {
                builder.AppendLine("Записи отсутствуют.");
                return builder.ToString();
            }

            foreach (var vehicle in vehicles)
            {
                builder.AppendLine($"ID: {vehicle.Id}");
                builder.AppendLine($"Гос. номер: {vehicle.Number}");
                builder.AppendLine($"Район: {vehicle.District}");
                builder.AppendLine($"Модель: {vehicle.Model}");
                builder.AppendLine($"Вместимость: {vehicle.Capacity}");
                builder.AppendLine($"Статус: {vehicle.Status}");
                builder.AppendLine(new string('-', 40));
            }

            return builder.ToString();
        }

        private string CreateCsv(List<VehicleDTO> vehicles)
        {
            var builder = new StringBuilder();
            builder.AppendLine("ID;Гос. номер;Район;Модель;Вместимость;Статус");

            foreach (var vehicle in vehicles)
            {
                builder.AppendLine(string.Join(";",
                    EscapeCsv(vehicle.Id.ToString()),
                    EscapeCsv(vehicle.Number),
                    EscapeCsv(vehicle.District),
                    EscapeCsv(vehicle.Model),
                    EscapeCsv(vehicle.Capacity.ToString()),
                    EscapeCsv(vehicle.Status)));
            }

            return builder.ToString();
        }

        private static string EscapeCsv(string value)
        {
            if (value == null)
                return string.Empty;

            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
    }
}
