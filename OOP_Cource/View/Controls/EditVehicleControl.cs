using System;
using System.Windows.Forms;
using OOP_Cource.Controller;
using OOP_Cource.DTO;

namespace OOP_Cource.View.Controls
{
    public partial class EditVehicleControl : UserControl
    {
        private readonly VehicleController _controller;
        private VehicleDTO _vehicle;

        public event Action BackButtonEvent;
        public event Action SaveButtonEvent;

        public EditVehicleControl(VehicleController controller) : this(controller, new VehicleDTO())
        {
        }

        public EditVehicleControl(VehicleController controller, VehicleDTO vehicle)
        {
            InitializeComponent();
            _controller = controller;
            _vehicle = vehicle;
        }

        private void EditVehicleControl_Load(object sender, EventArgs e)
        {
            FillFields();
        }

        private void FillFields()
        {
            NumberTextBox.Text = _vehicle.Number;
            DistrictTextBox.Text = _vehicle.District;
            ModelTextBox.Text = _vehicle.Model;
            CapacityTextBox.Text = _vehicle.Capacity.ToString();
            StatusComboBox.Text = _vehicle.Status;
        }

        public void SetVehicle(VehicleDTO vehicle)
        {
            _vehicle = vehicle;
            FillFields();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var number = NumberTextBox.Text;
                var district = DistrictTextBox.Text;
                var model = ModelTextBox.Text;
                var status = StatusComboBox.Text;

                if (!int.TryParse(CapacityTextBox.Text, out int capacity))
                    throw new ArgumentException("В поле 'Вместимость' введено не число!");

                await _controller.UpdateAsync(_vehicle.Id, number, district, model, capacity, status);

                MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SaveButtonEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка обновления данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            BackButtonEvent?.Invoke();
        }
    }
}
