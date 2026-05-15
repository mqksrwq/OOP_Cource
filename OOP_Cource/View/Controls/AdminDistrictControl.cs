using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP_Cource.Controller;
using OOP_Cource.DTO;
using OOP_Cource.Models;

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
        }

        private async void AdminDistrictControl_Load(object sender, EventArgs e)
        {
            await LoadAllVehiclesAsync();
        }

        private async Task LoadAllVehiclesAsync()
        {
            var vehicles = await _controller.GetByDistrictAsync(_district.ToString());
            LoadVehiclesByList(vehicles);
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
                    LoadVehiclesByList(new List<VehicleDTO> { vehicle });
                }
                else if (CriteriaComboBox.SelectedIndex == 1)
                {
                    var vehicles = await _controller.GetByNumberAsync(CriteriaValueTextBox.Text);
                    LoadVehiclesByList(vehicles);
                }
                else if (CriteriaComboBox.SelectedIndex == 2)
                {
                    var vehicles = await _controller.GetByModelAsync(CriteriaValueTextBox.Text);
                    LoadVehiclesByList(vehicles);
                }
                else if (CriteriaComboBox.SelectedIndex == 3)
                {
                    if (!int.TryParse(CriteriaValueTextBox.Text, out int capacity))
                        throw new ArgumentException("Вместимость должна быть числом!");

                    var vehicles = await _controller.GetByCapacityAsync(capacity);
                    LoadVehiclesByList(vehicles);
                }
                else if (CriteriaComboBox.SelectedIndex == 4)
                {
                    var vehicles = await _controller.GetByStatusAsync(CriteriaValueTextBox.Text);
                    LoadVehiclesByList(vehicles);
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
                await _controller.DeleteAllAsync();
                await LoadAllVehiclesAsync();
                MessageBox.Show("Все записи района удалены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            CloseButtonEvent?.Invoke();
        }
    }
}
